using ClassLibrary1;
using System;

namespace TimeAndTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(10, 10, 10);
            Time t2 = new Time(5, 5, 5);
            Console.Write("Expected false:");
            Console.WriteLine(t1 < t2);
            Console.Write("Expected true:");
            Console.WriteLine(t1 > t2);
            Console.Write("Expected true:");
            Console.WriteLine(t2 < t1);
            Console.Write("Expected false:");
            Console.WriteLine(t2 > t1);
            Console.Write("Expected false:");
            Console.WriteLine(t1.Equals(t2));
            Console.Write("Expected false:");
            Console.WriteLine(t1 == t2);
            Console.Write("Expected true:");
            Console.WriteLine(t1!=t2);
            Console.WriteLine("-------------- operators");
            Console.Write("Expected true:");
            Console.WriteLine(t1>=t2);
            Console.Write("Expected true:");
            Console.WriteLine(t2<=t1);
            Console.Write("Expected false:");
            Console.WriteLine(t1<= t2);
            Console.Write("Expected false:");
            Console.WriteLine(t2>=t1);




        }
    }
}
