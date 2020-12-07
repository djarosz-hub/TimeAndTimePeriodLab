using ClassLibrary;
using System;

namespace TimeAndTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presenting functionalities:");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Creating new Time obj (10:10:10)");
            Time t1 = new Time(10, 10, 10);
            Console.WriteLine("Created: " + t1.ToString());
            Console.WriteLine("Creating new TimePeriod obj (5:30:30)");
            TimePeriod tp1 = new TimePeriod(5, 30, 30);
            Console.WriteLine("Created: " + tp1.ToString());
            Console.WriteLine("---Time functionalities---");
            Time t2 = t1.AddTimePeriod(tp1);
            Time t3 = t1.SubstractTimePeriod(tp1);
            Console.WriteLine("Adding TimePeriod to Time: " + t2.ToString());
            Console.WriteLine("Substracting TimePeriod from Time: " + t3.ToString());
            TimePeriod testPeriodToSubstract = new TimePeriod(12, 20, 20);
            Console.WriteLine($"Created temporary TimePeriod: {testPeriodToSubstract.ToString()}");
            Console.WriteLine($"Substracting TimePeriod which is greater than actual hour: {t1.ToString()} - {testPeriodToSubstract.ToString()} = {Time.SubstractTimePeriod(t1,testPeriodToSubstract).ToString()}");
            Console.WriteLine("---Time Operators---");
            Time t4 = t1 + tp1;
            Console.WriteLine("Time + TimePeriod: " + t4.ToString());
            Time t5 = t1 - tp1;
            Console.WriteLine("Time - TimePeriod: " + t5.ToString());
            Time testTime = new Time(9, 0, 0);
            Console.WriteLine("Creating new Time 09:00:00 to test greater than and less than operator: " + testTime.ToString());
            Console.WriteLine($"{t1.ToString()} is greater than {testTime.ToString()}: {t1 > testTime}");
            Console.WriteLine($"{testTime.ToString()} is less than {t1.ToString()}: {testTime < t1}");
            Time testTime2 = new Time(10, 10, 10);
            Console.WriteLine("Creating new Time 10:10:10 to test greater or equal than and less or equal than operator: " + testTime2.ToString());
            Console.WriteLine($"{testTime2.ToString()} is greater or equal than {t1.ToString()}: {testTime2 >= t1}");
            Console.WriteLine($"{testTime2.ToString()} is less or equal than {t1.ToString()}: {testTime2 <= t1}");
            Console.WriteLine($"{testTime2.ToString()} == {t1.ToString()}: {testTime2 == t1}");
            Console.WriteLine($"{testTime.ToString()} != {testTime2.ToString()}: {testTime != testTime2}");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Earlier creater TimePeriod obj: " +tp1.ToString());
            Console.WriteLine("Creating another TimePeriod obj: 10:00:00");
            TimePeriod tp2 = new TimePeriod(10, 0, 0);
            Console.WriteLine("Created: " + tp2.ToString());
            Console.WriteLine("---TimePeriod functionalities---");
            Console.WriteLine("---Functions---");
            TimePeriod tp3 = TimePeriod.Substract(tp1, tp2);
            Console.WriteLine($"Substracting lesser period from greater period: {tp3.ToString()}");
            Console.WriteLine($"Adding both TimePeriods: {tp1+tp2}");
            Console.WriteLine("---Operators---");
            Console.WriteLine($"{tp2.ToString()} is greater than {tp1.ToString()}: {tp2>tp1}");
            Console.WriteLine($"{tp1.ToString()} is less than {tp2.ToString()}: {tp1<tp2}");
            Console.WriteLine("Creating test TimePeriod 10:00:00 to test greater/less or equal operator");
            TimePeriod tpTest = new TimePeriod(10, 0, 0);
            Console.WriteLine("Created: "+tpTest.ToString());
            Console.WriteLine($"{tp2.ToString()} is greater or equal than {tpTest.ToString()}: {tp2>=tpTest}");
            Console.WriteLine($"{tp2.ToString()} is less or equal than {tpTest.ToString()}: {tp2 <= tpTest}");
            Console.WriteLine("---Multiplying TimePeriods---");
            TimePeriod m2TP = new TimePeriod(5, 5, 5);
            TimePeriod m10TP = new TimePeriod(23, 55, 55);
            Console.WriteLine($"Created: {m2TP.ToString()}");
            Console.WriteLine($"Created: {m10TP.ToString()}");
            TimePeriod multiplied2 = m2TP.Multiply(2);
            Console.WriteLine($"Multiplying {m2TP.ToString()} by 2: {multiplied2.ToString()}");
            TimePeriod multiplied10 = m10TP.Multiply(10);
            Console.WriteLine($"Multiplying {m10TP.ToString()} by 10: {multiplied10.ToString()}");










        }

    }
}
