using System;
using System.IO;
using System.Text;
using System.Threading;
using Esp;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = File.ReadAllBytes("1.txt");

            string str1 = "password";
            string str2 = "*******";
            var arr2 = Encoding.Default.GetBytes(str1);
            var arr3 = Encoding.Default.GetBytes(str2);
            var l = new ReplaceOccurrenceArr1WithArr2(arr1, arr2, arr3);
            if (l.CountReplace > 0)
            {
                File.WriteAllBytes("2.txt",l.Result.ToArray());
            }
            
           var th1 = new Thread(R){Name = "Th1"};
           th1.Start();

           Console.ReadKey();
        }

        private static void R(object obj)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
        }
        private static void C(object obj)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
        }
    }
}
