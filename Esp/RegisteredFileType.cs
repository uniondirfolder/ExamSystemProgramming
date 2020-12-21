using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Esp
{

    public class RegisteredFileType
    {
        [DllImport("shell32.dll", EntryPoint = "ExtractIconA", CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern IntPtr ExtractIcon(
            int hInst,
            string lpszExeFileName,
            int nIconIndex);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern uint ExtractIconEx(
            string szFileName,
            int nIconIndex,
            IntPtr[] phiconLarge,
            IntPtr[] phiconSmall,
            uint nIcons);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DestroyIcon(IntPtr hIcon);

        public static List<string> GetFileType()
        {
            List<string> stringList = new List<string>();
            try
            {
                foreach (object key in GetFileTypeAndIcon().Keys)
                    stringList.Add(key.ToString());
                stringList.Sort();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stringList;
        }

        public static Hashtable GetFileTypeAndIcon()
        {
            try
            {
                RegistryKey classesRoot = Registry.ClassesRoot;
                string[] subKeyNames = classesRoot.GetSubKeyNames();
                Hashtable hashtable = new Hashtable();
                foreach (string name1 in subKeyNames)
                {
                    if (!string.IsNullOrEmpty(name1) && (uint)name1.IndexOf(".") <= 0U)
                    {
                        RegistryKey registryKey1 = classesRoot.OpenSubKey(name1);
                        if (registryKey1 != null)
                        {
                            object obj1 = registryKey1.GetValue("");
                            if (obj1 != null)
                            {
                                string name2 = obj1.ToString() + "\\DefaultIcon";
                                RegistryKey registryKey2 = classesRoot.OpenSubKey(name2);
                                if (registryKey2 != null)
                                {
                                    object obj2 = registryKey2.GetValue("");
                                    if (obj2 != null)
                                    {
                                        string str = obj2.ToString().Replace("\"", "");
                                        hashtable.Add((object)name1, (object)str);
                                    }

                                    registryKey2.Close();
                                }

                                registryKey1.Close();
                            }
                        }
                    }
                }

                classesRoot.Close();
                return hashtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Icon ExtractIconFromFile(string fileAndParam)
        {
            try
            {
                EmbeddedIconInfo embeddedIconInfo =
                    getEmbeddedIconInfo(fileAndParam);
                return Icon.FromHandle(ExtractIcon(0, embeddedIconInfo.FileName,
                    embeddedIconInfo.IconIndex));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Icon ExtractIconFromFile(string fileAndParam, bool isLarge)
        {
            IntPtr[] numArray1 = new IntPtr[1]
            {
                IntPtr.Zero
            };
            IntPtr[] numArray2 = new IntPtr[1]
            {
                IntPtr.Zero
            };
            try
            {
                EmbeddedIconInfo embeddedIconInfo = getEmbeddedIconInfo(fileAndParam);
                return (!isLarge
                        ? ExtractIconEx(embeddedIconInfo.FileName, 0, numArray1, numArray2, 1U)
                        : ExtractIconEx(embeddedIconInfo.FileName, 0, numArray2, numArray1, 1U)) >
                    0U && numArray2[0] != IntPtr.Zero
                        ? (Icon)Icon.FromHandle(numArray2[0]).Clone()
                        : (Icon)null;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not extract icon", ex);
            }
            finally
            {
                foreach (IntPtr hIcon in numArray2)
                {
                    if (hIcon != IntPtr.Zero)
                        DestroyIcon(hIcon);
                }

                foreach (IntPtr hIcon in numArray1)
                {
                    if (hIcon != IntPtr.Zero)
                        DestroyIcon(hIcon);
                }
            }
        }

        protected static EmbeddedIconInfo getEmbeddedIconInfo(
            string fileAndParam)
        {
            EmbeddedIconInfo embeddedIconInfo = new EmbeddedIconInfo();
            if (string.IsNullOrEmpty(fileAndParam))
                return embeddedIconInfo;
            string empty = string.Empty;
            int num = 0;
            string s = string.Empty;
            int length = fileAndParam.IndexOf(",");
            string str;
            if (length > 0)
            {
                str = fileAndParam.Substring(0, length);
                s = fileAndParam.Substring(length + 1);
            }
            else
                str = fileAndParam;

            if (!string.IsNullOrEmpty(s))
            {
                num = int.Parse(s);
                if (num < 0)
                    num = 0;
            }

            embeddedIconInfo.FileName = str;
            embeddedIconInfo.IconIndex = num;
            return embeddedIconInfo;
        }

        public enum ImageSize
        {
            Small,
            Large,
        }

        public struct EmbeddedIconInfo
        {
            public string FileName;
            public int IconIndex;
        }

    }
}