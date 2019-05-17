using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int m = 20;
        static int n = 15;
        static double[,] Matrix = new double[m,n];

        public static void EnterMatrix()
        {
           Random rnd = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matrix[i, j] = rnd.Next(4);
                    Console.Write(Matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }

        }
        static int number = 0;
        public static void CheckMatrix(int i, int j)
        {
            if (Matrix[i,j] != Matrix[i+1, j] & Matrix[i, j] != Matrix[i , j + 1] & Matrix[i, j] != Matrix[i+1, j + 1]
                & Matrix[i + 1, j] != Matrix[i, j + 1] & Matrix[i + 1, j] != Matrix[i+1, j + 1]
                & Matrix[i, j + 1] != Matrix[i + 1, j + 1])
            {                
                number += 1;
            }
        }
        static void Main(string[] args)
        {
            EnterMatrix();

            for (int i = 0; i < m-1; i++)
            {
                for (int j = 0; j < n-1; j++)
                {
                    Parallel.Invoke(() => CheckMatrix(i,j));
                }
               
            }
            Thread.Sleep(1000);
            Console.WriteLine("Number= " + number);
            Console.ReadKey();
        }
        

    }
}

