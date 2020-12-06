using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TimeTestMethods
    {
        [TestMethod]
        public void NoArgumentTimeConstructor()
        {
            Time t = new Time();
            string expected = "00:00:00";
            Assert.AreEqual(expected, t.ToString());
        }
        [DataTestMethod]
        [DataRow((byte)10, (byte)10)]
        [DataRow((byte)0, (byte)0)]
        [DataRow((byte)23, (byte)23)]
        public void OnlyHoursTimeConstructorCorrectValues(byte input, byte expected)
        {
            Time t = new Time(input);
            Assert.AreEqual(t.Hours, expected);
        }

        [DataTestMethod]
        [DataRow((byte)25)]
        [DataRow(byte.MaxValue)]
        [ExpectedException(typeof(Exception))]
        public void OnlyHoursTimeConstructorWrongValues(byte input)
        {
            Time t = new Time(input);
        }

        [DataTestMethod]
        [DataRow("random text")]
        [DataRow("")]
        [DataRow("hours:mins:secs")]
        [DataRow("15:5::")]
        [DataRow("3:5,2,:")]
        [DataRow("24:59:59")]
        [ExpectedException(typeof(FormatException))]
        public void TimeStringWrongConstructor(string input)
        {
            Time t = new Time(input);
        }

        [DataTestMethod]
        [DataRow("0:0:0")]
        [DataRow("00:00:00")]
        [DataRow("15:23:59")]
        [DataRow("23:00:1")]
        [DataRow("1:59:0")]
        public void TimeStringCorrectConstructor(string input)
        {
            Time t = new Time(input);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)5, (byte)1, (byte)5)]
        [DataRow((byte)23, (byte)0, (byte)23, (byte)0)]
        [DataRow((byte)0, (byte)1, (byte)0, (byte)1)]
        public void TwoArgsTimeConstructorCorrectValues(byte hours, byte mins, byte expectedHours, byte expectedMins)
        {
            Time t = new Time(hours, mins);
            Assert.AreEqual(expectedHours, t.Hours);
            Assert.AreEqual(expectedMins, t.Minutes);
        }

        [DataTestMethod]
        [DataRow((byte)25, (byte)60)]
        [ExpectedException(typeof(Exception))]
        public void TwoArgsTimeConstructorWrongValues(byte hours, byte mins)
        {
            Time t = new Time(hours, mins);
        }

        [DataTestMethod]
        [DataRow((byte)25, (byte)59, (byte)35)]
        [DataRow((byte)23, (byte)60, (byte)35)]
        [DataRow((byte)23, (byte)59, (byte)66)]
        [ExpectedException(typeof(Exception))]
        public void ThreeArgsConstructorWrongValues(byte hours, byte mins, byte secs)
        {
            Time t = new Time(hours, mins, secs);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)35, (byte)23, (byte)59, (byte)35)]
        [DataRow((byte)0, (byte)6, (byte)2, (byte)0, (byte)6, (byte)2)]
        [DataRow((byte)1, (byte)1, (byte)59, (byte)1, (byte)1, (byte)59)]
        public void ThreeArgsConstructorCorrectValues(byte hours, byte mins, byte secs, byte exH, byte exM, byte exS)
        {
            Time t = new Time(hours, mins, secs);
            Assert.AreEqual(exH, t.Hours);
            Assert.AreEqual(exM, t.Minutes);
            Assert.AreEqual(exS, t.Seconds);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)59, "23:59:59")]
        [DataRow((byte)0, (byte)0, (byte)0, "00:00:00")]
        [DataRow((byte)10, (byte)0, (byte)1, "10:00:01")]
        [DataRow((byte)20, (byte)51, (byte)2, "20:51:02")]
        public void ToStringRepresentation(byte h, byte m, byte s, string expected)
        {
            Time t = new Time(h, m, s);
            Assert.AreEqual(expected, t.ToString());
        }
        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)59, "23:59:59")]
        [DataRow((byte)0, (byte)0, (byte)0, "00:00:00")]
        [DataRow((byte)10, (byte)0, (byte)1, "10:00:01")]
        [DataRow((byte)20, (byte)51, (byte)2, "20:51:02")]
        public void EqualOperatorTestThreeArgsAndByStringConstructors(byte h, byte m, byte s, string input)
        {
            Time t1 = new Time(h, m, s);
            Time t2 = new Time(input);
            Assert.AreEqual(true, t1 == t2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)56, "23:59:59")]
        [DataRow((byte)0, (byte)0, (byte)1, "00:00:00")]
        [DataRow((byte)10, (byte)0, (byte)2, "10:00:01")]
        [DataRow((byte)20, (byte)51, (byte)3, "20:51:02")]
        public void NotEqualOperatorTestThreeArgsAndByStringConstructors(byte h, byte m, byte s, string input)
        {
            Time t1 = new Time(h, m, s);
            Time t2 = new Time(input);
            Assert.AreEqual(true, t1 != t2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)56, (byte)23, (byte)58, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)1)]
        [DataRow((byte)20, (byte)0, (byte)0, (byte)19, (byte)0, (byte)0)]
        public void GreaterThanOperatorTest(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, t1 > t2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)56, (byte)23, (byte)56, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)2)]
        [DataRow((byte)20, (byte)0, (byte)0, (byte)19, (byte)5, (byte)0)]
        public void GreaterOrEqualThanOperatorTest(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, t1 >= t2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)56, (byte)23, (byte)58, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)0)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)1)]
        [DataRow((byte)20, (byte)0, (byte)0, (byte)19, (byte)0, (byte)0)]
        public void WeakerThanOperatorTest(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);
            Assert.AreEqual(false, t1 < t2);
        }

        [DataTestMethod]
        [DataRow((byte)23, (byte)58, (byte)56, (byte)23, (byte)58, (byte)56)]
        [DataRow((byte)0, (byte)0, (byte)1, (byte)0, (byte)0, (byte)2)]
        [DataRow((byte)10, (byte)0, (byte)2, (byte)10, (byte)0, (byte)3)]
        [DataRow((byte)20, (byte)0, (byte)0, (byte)23, (byte)0, (byte)0)]
        public void WeakerOrEqualThanOperatorTest(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);
            Assert.AreEqual(true, t1 <= t2);
        }

        [DataTestMethod]
        [DataRow((byte)10, (byte)10, (byte)10, (long)360, "10:16:10")]
        [DataRow((byte)0, (byte)0, (byte)0, (long)60, "00:01:00")]
        [DataRow((byte)10, (byte)10, (byte)10, (long)3600, "11:10:10")]
        [DataRow((byte)1, (byte)25, (byte)40, (long)2061, "02:00:01")]
        [DataRow((byte)23, (byte)59, (byte)59, (long)7201, "02:00:00")]
        public void AddingPeriodToTimeFuncsAndOperatorTest(byte h, byte m, byte s, long period, string output)
        {
            Time t1 = new Time(h, m, s);
            TimePeriod tp1 = new TimePeriod(period);

            Time t2 = t1.AddTimePeriod(tp1);
            Assert.AreEqual(output, t2.ToString());

            Time t3 = Time.AddTimePeriod(t1, tp1);
            Assert.AreEqual(output, t3.ToString());

            Time t4 = t1 + tp1;
            Assert.AreEqual(output, t4.ToString());
        }

        [DataTestMethod]
        [DataRow((byte)10, (byte)10, (byte)10, (long)610, "10:00:00")]
        [DataRow((byte)0, (byte)0, (byte)0, (long)60, "23:59:00")]
        [DataRow((byte)10, (byte)10, (byte)10, (long)3600, "09:10:10")]
        [DataRow((byte)1, (byte)25, (byte)40, (long)(3600 + 25 * 60 + 39), "00:00:01")]
        [DataRow((byte)23, (byte)59, (byte)59, (long)7199, "22:00:00")]
        public void SubstractingPeriodFromTimeFuncsAndOperatorTest(byte h, byte m, byte s, long period, string output)
        {
            Time t1 = new Time(h, m, s);
            TimePeriod tp1 = new TimePeriod(period);

            Time t2 = t1.SubstractTimePeriod(tp1);
            Assert.AreEqual(output, t2.ToString());

            Time t3 = Time.SubstractTimePeriod(t1, tp1);
            Assert.AreEqual(output, t3.ToString());

            Time t4 = t1 - tp1;
            Assert.AreEqual(output, t4.ToString());
        }
    }

    [TestClass]
    public class TimePeriodTestMethods
    {
        [TestMethod]
        public void NoArgumentTimePeriodConstructor()
        {
            TimePeriod tp = new TimePeriod();
            string expected = "00:00:00";
            Assert.AreEqual(expected, tp.ToString());
        }
        [DataTestMethod]
        [DataRow(100, 100)]
        [DataRow(0, 0)]
        [DataRow(523423, 523423)]
        public void OnlySecondsTimePeriodConstructorCorrectValues(long seconds, long expected)
        {
            TimePeriod tp = new TimePeriod(seconds);
            Assert.AreEqual(expected, tp.PeriodInSeconds);
        }
        [DataTestMethod]
        [DataRow(long.MaxValue)]
        [DataRow(-2)]
        [ExpectedException(typeof(Exception))]
        public void OnlySecondsTimePeriodConstructorWrongValues(long seconds)
        {
            seconds++;
            TimePeriod tp = new TimePeriod(seconds);
        }

        [DataTestMethod]
        [DataRow("random text")]
        [DataRow("")]
        [DataRow("hours:mins:secs")]
        [DataRow("15:5::")]
        [DataRow("3:5,2,:")]
        [DataRow("2147483648:59:59")]//int max value +1
        [ExpectedException(typeof(FormatException))]
        public void TimePeriodStringWrongConstructor(string input)
        {
            TimePeriod t = new TimePeriod(input);
        }

        [DataTestMethod]
        [DataRow("0:0:0")]
        [DataRow("00:00:00")]
        [DataRow("15:23:59")]
        [DataRow("23:00:1")]
        [DataRow("1:59:0")]
        [DataRow("2147483647:59:59")]
        public void TimePeriodStringCorrectConstructor(string input)
        {
            TimePeriod t = new TimePeriod(input);
        }

        [DataTestMethod]
        [DataRow((byte)1, (byte)5, 3900)]
        [DataRow((byte)23, (byte)0, 23 * 3600)]
        [DataRow((byte)0, (byte)1, 60)]
        public void TwoArgsTimePeriodConstructor(byte hours, byte mins, long expectedPeriod)
        {
            TimePeriod tp = new TimePeriod(hours, mins);
            Assert.AreEqual(expectedPeriod, tp.PeriodInSeconds);
        }


        [DataTestMethod]
        [DataRow((byte)23, (byte)59, (byte)35, (byte)23, (byte)59, (byte)35, 0)]
        [DataRow((byte)0, (byte)8, (byte)2, (byte)0, (byte)6, (byte)2, 120)]
        [DataRow((byte)1, (byte)1, (byte)59, (byte)10, (byte)1, (byte)59, 9 * 3600)]
        public void TwoTimeStructsTimePeriodConstructor(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2, long expectedPeriod)
        {
            Time t1 = new Time(h1, m1, s1);
            Time t2 = new Time(h2, m2, s2);
            TimePeriod tp1 = new TimePeriod(t1, t2);
            Assert.AreEqual(expectedPeriod, tp1.PeriodInSeconds);
        }
        [DataTestMethod]
        [DataRow(0, 0, 0, 0)]
        [DataRow(100,10,10, 360610)]
        [DataRow(int.MaxValue,0,0,(long)int.MaxValue*3600)]
        public void ThreeArgsTimePeriodCorrectValuesConstructor(int h, int m, int s, long period)
        {
            TimePeriod tp1 = new TimePeriod(h, m, s);
            Assert.AreEqual(period, tp1.PeriodInSeconds);
        }
        [DataTestMethod]
        [DataRow(int.MaxValue,0,0)]
        [DataRow(-1,60,0)]
        [DataRow(-1,0,60)]
        [DataRow(-2,-1,-1)]
        [ExpectedException(typeof(Exception))]
        public void ThreeArgsTimePeriodWrongValuesConstructor(int h, int m, int s)
        {
            h++;
            TimePeriod tp1 = new TimePeriod(h, m, s);
        }

        [DataTestMethod]
        [DataRow(3600,"01:00:00")]
        [DataRow(36000, "10:00:00")]
        [DataRow(360000, "100:00:00")]
        [DataRow(3666, "01:01:06")]
        [DataRow(0, "00:00:00")]

        public void ToStringRepresentation(long period, string expected)
        {
            TimePeriod tp = new TimePeriod(period);
            Assert.AreEqual(expected, tp.ToString());
        }
        [DataTestMethod]
        [DataRow(3600,"01:00:00")]
        [DataRow(0, "0:0:0")]
        [DataRow(24*3600,"24:00:00")]

        public void EqualOperatorByStringConstructorAndSecondsOne(long period,string input)
        {
            TimePeriod tp1 = new TimePeriod(period);
            TimePeriod tp2 = new TimePeriod(input);
            Assert.AreEqual(true, tp1 == tp2);

        }
        [DataTestMethod]
        [DataRow(3601, "01:00:00")]
        [DataRow(1, "0:0:0")]
        [DataRow(23 * 3600, "24:00:00")]

        public void NotEqualOperatorByStringConstructorAndSecondsOne(long period, string input)
        {
            TimePeriod tp1 = new TimePeriod(period);
            TimePeriod tp2 = new TimePeriod(input);
            Assert.AreEqual(true, tp1 != tp2);

        }

        [DataTestMethod]
        [DataRow(10,9)]
        [DataRow(1,0)]
        [DataRow(1111111,11111)]
        [DataRow(long.MaxValue,long.MaxValue-1)]
        public void GreaterThanOperator(long period1, long period2)
        {
            Assert.AreEqual(true, period1 > period2);
        }

        [DataTestMethod]
        [DataRow(10, 10)]
        [DataRow(1, 0)]
        [DataRow(1111111, 11111)]
        [DataRow(long.MaxValue, long.MaxValue - 1)]
        [DataRow(long.MaxValue, long.MaxValue)]
        [DataRow(0,0)]
        public void GreaterOrEqualThanOperator(long period1, long period2)
        {
            Assert.AreEqual(true, period1 >= period2);
        }

        [DataTestMethod]
        [DataRow(10, 11)]
        [DataRow(0, 1)]
        [DataRow(111, 11111)]
        [DataRow(long.MaxValue-1, long.MaxValue)]
        public void WeakerThanOperator(long period1, long period2)
        {
            Assert.AreEqual(true, period1 < period2);
        }

        [DataTestMethod]
        [DataRow(10, 10)]
        [DataRow(0, 1)]
        [DataRow(11111, 11111)]
        [DataRow(long.MaxValue-1, long.MaxValue)]
        [DataRow(long.MaxValue, long.MaxValue)]
        [DataRow(0, 0)]
        public void WeakerOrEqualThanOperator(long period1, long period2)
        {
            Assert.AreEqual(true, period1 <= period2);
        }

        [DataTestMethod]
        [DataRow(100,100,200)]
        [DataRow(int.MaxValue,int.MaxValue,(long)int.MaxValue*2)]
        public void AddingTimePeriodToTimePeriodFuncsAndOperatorTest(long period1, long period2, long expectedPeriod)
        {
            TimePeriod tp1 = new TimePeriod(period1);
            TimePeriod tp2 = new TimePeriod(period2);

            TimePeriod t3 = tp1.Add(tp2);
            Assert.AreEqual(expectedPeriod, t3.PeriodInSeconds);

            TimePeriod t4 = TimePeriod.Add(tp1, tp2);
            Assert.AreEqual(expectedPeriod, t4.PeriodInSeconds);

            TimePeriod t5 = tp1 + tp2;
            Assert.AreEqual(expectedPeriod, t5.PeriodInSeconds);

        }
        [DataTestMethod]
        [DataRow(0,0)]
        [DataRow(long.MaxValue,long.MaxValue)]
        [ExpectedException(typeof(Exception))]
        public void AddingTimePeriodToTimePeriodFuncsAndOperatorTestWrongValues(long period1, long period2)
        {
            TimePeriod tp1 = new TimePeriod(period1);
            TimePeriod tp2 = new TimePeriod(period2);
            TimePeriod t3 = tp1.Add(tp2);
            TimePeriod t4 = TimePeriod.Add(tp1, tp2);
            TimePeriod t5 = tp1 + tp2;

        }

        [DataTestMethod]
        [DataRow(200,100,100)]
        [DataRow(200,300,0)]
        [DataRow(int.MaxValue,int.MaxValue-1,1)]

        public void SubstractingTimePeriodFromTimePeriodFuncAndOperatorTest(long period1, long period2, long expectedPeriod)
        {
            TimePeriod tp1 = new TimePeriod(period1);
            TimePeriod tp2 = new TimePeriod(period2);

            TimePeriod tp3 = tp1.Substract(tp2);
            Assert.AreEqual(expectedPeriod, tp3.PeriodInSeconds);

            TimePeriod tp4 = tp1 - tp2;
            Assert.AreEqual(expectedPeriod, tp4.PeriodInSeconds);

        }
        [DataTestMethod]
        [DataRow(100,101,1)]
        [DataRow(100,200,100)]
        [DataRow(0,0,0)]
        [DataRow(long.MaxValue, 0,long.MaxValue)]
        public void SubstractingTimePeriodStaticMethodTest(long period1, long period2, long expectedPeriod)
        {
            TimePeriod tp1 = new TimePeriod(period1);
            TimePeriod tp2 = new TimePeriod(period2);
            TimePeriod t3 = TimePeriod.Substract(tp1, tp2);
            Assert.AreEqual(expectedPeriod, t3.PeriodInSeconds);
        }

    }
}
