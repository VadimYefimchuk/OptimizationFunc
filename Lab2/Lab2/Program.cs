using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
                //Перший потік
                Thread FirstThread = new Thread(new ParameterizedThreadStart(myfunc.FirstFunc));
                FirstThread.Start(n);
                FirstThread.Join();
                //Другий потік
                Thread SecondThread = new Thread(new ParameterizedThreadStart(myfunc.SecondFunc));
                SecondThread.Start(n);
                SecondThread.Join();
                //Третій потік
                Thread ThirdThread = new Thread(new ParameterizedThreadStart(myfunc.ThirdFunc));
                ThirdThread.Start(n);
                ThirdThread.Join();
                //////////////////////////////////////
                FirstThread = new Thread(new ParameterizedThreadStart(myfunc.FourthFunc));
                FirstThread.Start(n);
                FirstThread.Join();

                SecondThread = new Thread(new ParameterizedThreadStart(myfunc.FivethFunc));
                SecondThread.Start(n);
                SecondThread.Join();

                ThirdThread = new Thread(new ParameterizedThreadStart(myfunc.SixthFunc));
                ThirdThread.Start(n);
                ThirdThread.Join();

                Thread FinalThread = new Thread(new ParameterizedThreadStart(myfunc.FinalFunc));
                FinalThread.Start(n);
                FinalThread.Join();
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
