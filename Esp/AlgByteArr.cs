using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Esp
{
    public abstract class ArrLock
    {
        protected object Lock = new object();
    }
    public class AlgByteArr
    {
        public static bool ComparisonByteArr(byte[] arr1, byte[] arr2)
        {
            if (arr1 == null || arr2 == null)
            {
                return false;
            }

            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            int i = 0;
            int j = arr1.Length;
            while (i<j)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }
        public static byte[] GetCopyPortionArr(byte[] resource, int indexStart, int indexEnd )
        {
            if(resource== null || indexStart>=indexEnd || indexStart<0 || indexEnd > resource.Length)
            { throw new Exception("GetCopyPortionArray: obj null");}

            byte[] arr = new byte[indexEnd - indexStart];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = resource[indexStart + i];
            }

            return arr;
        }

    }

    public class ReplaceOccurrenceArr1WithArr2:ArrLock
    {
        public List<byte> Result = new List<byte>();
        public int CountReplace = 0;
        private readonly byte[] _resource;
        private readonly byte[] _arrOriginal;
        private readonly byte[] _arrReplaceable;
        public ReplaceOccurrenceArr1WithArr2(byte[] resource, byte[]arrOriginal, byte[] arrReplaceable)
        {
            if(resource== null || arrOriginal==null || arrReplaceable == null) { throw new Exception(" ReplaceOccurrenceArr1WithArr2 obj null");}

            lock (Lock)
            {
                this._resource = resource;
                this._arrOriginal = arrOriginal;
                this._arrReplaceable = arrReplaceable;
                FillList();
            }
        }

        private void FillList()
        {
            for (int i = 0, j = _resource.Length -_arrOriginal.Length+1, s = _arrOriginal.Length; i < j;)
            {
                if (_resource[i] == _arrOriginal[0])
                {
                    byte[] arr = AlgByteArr.GetCopyPortionArr(_resource, i, i+s);
                    if (AlgByteArr.ComparisonByteArr(arr,_arrOriginal))
                    {
                        Result.AddRange(_arrReplaceable);
                        i += s;
                        CountReplace++;
                    }
                    else
                    {
                        Result.Add(_resource[i]);
                        i++;
                    }
                }
                else
                {
                    Result.Add(_resource[i]);
                    i++;
                }
            }
            if (CountReplace == 0)
            {
                Result.Clear();
            }
        }
    }
}