using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1-Thread or 2-Function");
            char tree = Convert.ToChar(Console.ReadLine());
            if (tree == '1')
            {
                Console.WriteLine("Enter N");
                int n = Convert.ToInt32(Console.ReadLine());
                MyFunc myfunc = new MyFunc();
                Parallel.Invoke(() => myfunc.FirstFunc(n), () => myfunc.SecondFunc(n), () => myfunc.ThirdFunc(n));
                Thread.Sleep(1000);
                Parallel.Invoke(() => myfunc.FourthFunc(n), () => myfunc.FivethFunc(n), () => myfunc.SixthFunc(n));
                Thread.Sleep(1000);
                Parallel.Invoke(() => myfunc.FinalFunc(n));

            }
            else
            {
                Console.WriteLine("Enter N");
                int n = Convert.ToInt32(Console.ReadLine());
                MyFunc myfunc = new MyFunc();
                myfunc.FirstFunc(n);
                myfunc.SecondFunc(n);
                myfunc.ThirdFunc(n);
                myfunc.FourthFunc(n);
                myfunc.FivethFunc(n);
                myfunc.SixthFunc(n);
                myfunc.FinalFunc(n);
            }
            Console.ReadKey();
        }


    }

}
