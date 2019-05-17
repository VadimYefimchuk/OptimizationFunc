using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class MyFunc 
    {
        public Matrix A;
        public Matrix b;
        public Matrix y1;

        public void FirstFunc(object x)
        {
            int n = (int)x;
            A = new Matrix(n, n);
            b = new Matrix(n, 1);
            

            A.Random();
            b.Random();
            y1 = A * b;

            Console.WriteLine("Array A");
            Console.WriteLine(A);
            Console.WriteLine("Array b");
            Console.WriteLine(b);
            Console.WriteLine("Array y1");
            Console.WriteLine(y1);

        }

        public Matrix A1;
        public Matrix b1;
        public Matrix c1;
        public Matrix y2;
        public void SecondFunc(object x)
        {
            int n = (int)x;
            A1 = new Matrix(n, n);
            b1 = new Matrix(n, 1);
            c1 = new Matrix(n, 1);
            A1.Random();
            b1.Random();
            c1.Random();
            Console.WriteLine("Array A1");
            Console.WriteLine(A1);
            Console.WriteLine("Array b1");
            Console.WriteLine(b1);
            Console.WriteLine("Array c1");
            Console.WriteLine(c1);
            b1.ArrayMulti6();
            Console.WriteLine("Array y2");
            y2 = A1 * (b1-c1);
            Console.WriteLine(y2);
            
        }
        public Matrix A2;
        public Matrix B2;
        public Matrix C2;
        public Matrix Y3;
        public void ThirdFunc(object x)
        {
            int n = (int)x;
            A2 = new Matrix(n, n);
            B2 = new Matrix(n, n);
            C2 = new Matrix(n, n);
            A2.Random();
            B2.Random();
            C2.ArrayGenerateC2();
            Console.WriteLine("Array A2");
            Console.WriteLine(A2);
            Console.WriteLine("Array B2");
            Console.WriteLine(B2);
            Console.WriteLine("Array C2");
            Console.WriteLine(C2);
            B2.ArrayMulti10();
            Y3 = A2 * (B2 + C2);
            Console.WriteLine("Array Y3");
            Console.WriteLine(Y3);
        }
        //Є нюанси з множенням матриць
        Matrix F1, F2, F3;
        public void FourthFunc(object x)
        {
            F1 = y2.Transpose()*Y3*Y3;
        }

        public void FivethFunc(object x)
        {
            F2 = y2.Transpose() * Y3 * Y3 * Y3;
        }

        public void SixthFunc(object x)
        {
            F3 = y2.Transpose() * Y3 ;
        }
        Matrix final;
        public void FinalFunc(object x)
        {
           final=F1+F2+F3;
            final.FinalNormalization();
            Console.WriteLine("Array FINAL");
            Console.WriteLine(final);
        }
    }
}
