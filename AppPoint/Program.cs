using System;
using Points;


namespace AppPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(3, 2);
            A.Permuter();
            Console.WriteLine(A.ToString());
            A.Deplacer(5,5);
            Console.WriteLine("--------------- Point---------------------");
            Console.WriteLine(A);
            Point B = A.SymAbs();
            Console.WriteLine(B);
            Point C = A.SymOrd();
            Console.WriteLine(C);
            Point D = A.SymO();
            Console.WriteLine(D);
            Point test = new Point(9, 7);
            double mesureSegment = A.MesureDistance(test);
            mesureSegment = Math.Round(mesureSegment, 3);
            Console.WriteLine(mesureSegment);
           double res= Point.Distance(A, test);
            Console.WriteLine(Math.Round(res,3));
            Console.ReadLine();
            // Console.WriteLine("Hello World!");
        }
    }
}
