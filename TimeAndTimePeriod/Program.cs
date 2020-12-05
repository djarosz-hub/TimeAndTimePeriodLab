using ClassLibrary;
using System;

namespace TimeAndTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(23, 59, 59);
            TimePeriod tp1 = new TimePeriod(2, 1,1);
            TimePeriod tp2 = new TimePeriod(25,59,59);
            Time test1 = t1.SubstractTimePeriod(tp1);
            Time test2 = t1.SubstractTimePeriod(tp2);
            Console.WriteLine(test1.ToString());
            Console.WriteLine(test2.ToString());

            //Time t1 = new Time(5);
            //Console.WriteLine(t1.ToString());
            //Time t1 = new Time(1);
            //Time t1 = new Time(1, 10, 10);
            //Time t2 = new Time(0, 10, 10);
            //Time t3 = new Time(10, 10, 10);
            //TimePeriod t4 = new TimePeriod(t1, t2);
            //Console.WriteLine(t4.ToString());
            //TimePeriod tp1 = new TimePeriod(100);
            //TimePeriod tp2 = new TimePeriod(100);
            //TimePeriod tp3 = new TimePeriod(200);
            //Console.Write("Expected true:");
            //Console.WriteLine(tp1==tp2);
            //Console.Write("Expected false:");
            //Console.WriteLine(tp1 != tp2);
            //Console.Write("Expected false:");
            //Console.WriteLine(tp1 > tp3);
            //Console.Write("Expected true:");
            //Console.WriteLine(tp1 >= tp2);
            //Console.Write("Expected true:");
            //Console.WriteLine(tp1 < tp3);
            //Console.Write("Expected true:");
            //Console.WriteLine(tp1 <= tp2);
            //TimePeriod tpx = tp3.Substract(tp2);
            //Console.WriteLine(tpx.ToString());
            //Console.WriteLine("---");
            //TimePeriod tpp1 = TimePeriod.Substract(tp3, tp1);
            //Console.WriteLine(tpp1.ToString());
            //TimePeriod tpp2 = TimePeriod.Substract(tp1, tp3);
            //Console.WriteLine(tpp2.ToString());
            //TimePeriod tpp3 = TimePeriod.Substract(tp1, tp2);
            //Console.WriteLine(tpp3.ToString());
            //Console.WriteLine("new test");
            //TimePeriod test1 = new TimePeriod(10, 10, 10);
            //TimePeriod test2 = new TimePeriod(9, 5, 5);
            //Console.Write("expected: 01:05:05 --- ");
            //TimePeriod test3 = TimePeriod.Substract(test2, test1);
            //Console.WriteLine(test3.ToString());






            //Time t1 = new Time(10, 10, 10);
            //Time t2 = new Time(5, 5, 5);
            //Console.Write("Expected false:");
            //Console.WriteLine(t1 < t2);
            //Console.Write("Expected true:");
            //Console.WriteLine(t1 > t2);
            //Console.Write("Expected true:");
            //Console.WriteLine(t2 < t1);
            //Console.Write("Expected false:");
            //Console.WriteLine(t2 > t1);
            //Console.Write("Expected false:");
            //Console.WriteLine(t1.Equals(t2));
            //Console.Write("Expected false:");
            //Console.WriteLine(t1 == t2);
            //Console.Write("Expected true:");
            //Console.WriteLine(t1 != t2);
            //Console.WriteLine("-------------- operators");
            //Console.Write("Expected true:");
            //Console.WriteLine(t1 >= t2);
            //Console.Write("Expected true:");
            //Console.WriteLine(t2 <= t1);
            //Console.Write("Expected false:");
            //Console.WriteLine(t1 <= t2);
            //Console.Write("Expected false:");
            //Console.WriteLine(t2 >= t1);
            //Console.WriteLine("--------------");
            //Console.Write("Expected false:");
            //Time t3 = new Time(0, 0, 1);
            //Time t4 = new Time(0, 1, 0);
            //Console.WriteLine(t3 > t4);
            //Console.Write("Expected false:");
            //Console.WriteLine(t3 >= t4);


        }
    }
}
