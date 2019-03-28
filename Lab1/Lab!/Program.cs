using System;
using System.Threading;


class ThreadSafe
{
    static bool done;
    static object locker = new object();

    static void Main(string[] args)
    {
        new Thread(Go).Start();
        Go();
        Console.ReadLine();
    }

    static void Go()
    {
        lock (locker)
        {
            if (!done)
            {
                Console.Write("Done");
                done = true;
            }
        }
    }
}