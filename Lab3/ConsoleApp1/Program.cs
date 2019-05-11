using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static int n =5;
        static double[,] A = new double[n, n];
        static double[,] B = new double[n, n];
        static void Main(string[] args)
        {

            Parallel.Invoke(() => SetA(n), () => SetB(n));
            Thread.Sleep(1000);

            Console.WriteLine("");
            MatrixSimple();
            MatrixLocal2();
            Console.ReadKey();
        }
        public static void SetA(int n)
        {
            Console.WriteLine("Array A");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j <= i && i >= n - j - 1)
                        A[i, j] = n+1;
                    if (j >= i && i <= n - j - 1)
                        A[i, j] = n-1;

                    Console.Write(A[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Thread.Sleep(0);
        }
        static void SetB(int n)
        {
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Array B");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B[i, j] = 0;
                    if (i <= j)
                    {
                        B[i, j] = 1;
                    }
                    Console.Write(B[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Thread.Sleep(0);
        }
        public static void MatrixSimple()
        {
            int Z = 0;
            Console.WriteLine("Array C");
            int N = n;
            double[,,] C = new double[N, N, N+1];
            for (int i = 0; i < N; i++)
            {
                
                for (int j = 0; j < N; j++)
                {

                    for (int k = 0; k < N; k++)
                    {
                        C[i, j,k] =  A[i, k] * B[k, j];

                        Z += 1;
                    }
                    for (int k = 1; k < N; k++)
                    {
                        C[i, j,0] += C[i, j, k] ;

                        Z += 1;
                    }


                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(C[i, j,0] + "  ");
                }
                Console.WriteLine();

            }
            Console.WriteLine("Number of operation Simple = " + Z);
        }
        public static void MatrixLocal()
        {
            int Z = 0;
            Console.WriteLine("Array C");
            int N = n;
            double[,] C = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                        Z += 1;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(C[i, j] + "  ");
                }
                Console.WriteLine();

            }
            Console.WriteLine("Number of operation Local = " + Z);
        }



        public static void MatrixLocal2()
        {
            int Z = 0;
            Console.WriteLine("Array C");
            int N = n;
            double[,,] C = new double[N, N, N + 1];
            double[,,] A2 = new double[N, N, N + 1];
            double[,,] B2 = new double[N, N, N + 1];

            for (int b = 0; b < N; b++)
            {
                for (int g = 0; g < N; g++)
                {
                    A2[b, g, 0] = A[b, g];
                    B2[b, g, 0] = B[b, g];
                    
                }
                
               // Console.WriteLine();
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    
                    for (int k = 0; k < N; k++)
                    {
                     
                        for (int S = 0; S < N; S++)
                        {
                            A2[j, S, 0] = A[j, S];
                            B2[S,k,0] = B[S,k];


                            C[i, j, S + 1] = C[i, j, S] + A2[j, S,i] * B2[S,k,i];
                            A2[i, k, S + 1] = A2[i, k, S];
                            B2[k, j, S + 1] = B2[k, j, S];

                            Z += 1;
                        }
                    }
                }
            }
            Console.WriteLine();

                for (int j = 0; j < n; j++)
               {
                    for (int k = 1; k < n+1; k++)
                    {
                        Console.Write(C[n-1, j, k] + "  ");
                    }
                    Console.WriteLine();
               }
                

            Console.WriteLine("Number of operation Local = " + Z);
        }

    }
}
