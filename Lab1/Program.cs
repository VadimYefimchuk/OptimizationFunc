using System;
using System.Threading;


class Program
{
    static void Main(string[] args)
    {
        new Thread(Go).Start();
        Go();
    }

    static void Go()
    {
        for (int i = 0; i < 5; i++)
            Console.Write('P');
    }
}

