using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Time struct constructor needs at least one input value, otherwise auto generated constructor will be called and fields would be filled by default values (0)
    /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        ///<value>Gets number of hours in Time struct</value>
        public readonly byte Hours { get; }
        ///<value>Gets number of minutes in Time struct</value>
        public readonly byte Minutes { get; }
        ///<value>Gets number of seconds in Time struct</value>
        public readonly byte Seconds { get; }
        /// <summary>
        /// Correct range of input is: 0-23, other input value will cause exception to be thrown; minutes and seconds value will be 0 by default
        /// </summary>
        /// <param name="hours"></param>
        public Time(byte hours)
        {
            if (hours > 23 || hours < 0)
                throw new Exception("input value out of range");
            this.Hours = hours;
            this.Minutes = 0;
            this.Seconds = 0;
        }
        /// <summary>
        /// Correct range of input is: 0-23 for hours, 0-59 for minutes, other input value will cause exception to be thrown; seconds value will be 0 by default
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        public Time(byte hours, byte minutes)
        {
            if (hours > 23 || hours < 0)
                throw new Exception("input value out of range");
            if (minutes > 59 || minutes < 0)
                throw new Exception("input value out of range");
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = 0;
        }
        /// <summary>
        /// Correct range of input values is: hours: 0-23; minutes 0-59; seconds: 0-59; passing values out of range will cause exception to be thrown
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public Time(byte hours, byte minutes, byte seconds)
        {
            this.Hours = verify(hours, 0, 23);
            this.Minutes = verify(minutes, 0, 59);
            this.Seconds = verify(seconds, 0, 59);
            byte verify(byte val, int min, int max)
            {
                if (val >= min && val <= max)
                    return val;
                else
                    throw new Exception("input value out of range");
            }
        }
        /// <summary>
        /// Input string requires to be formatted like "hh:mm:ss" in range "(0-23:0-59:0-59)", otherwise exception will be thrown
        /// </summary>
        /// <param name="input"></param>
        public Time(string input)
        {
            if (!input.Contains(":") || string.IsNullOrEmpty(input))
                throw new FormatException("expected format hh:mm:ss");
            string[] parts = input.Split(':');
            if (parts.Length != 3)
                throw new FormatException("expected format hh:mm:ss");
            bool flagH, flagM, flagS;
            flagH = int.TryParse(parts[0], out int h);
            flagM = int.TryParse(parts[1], out int m);
            flagS = int.TryParse(parts[2], out int s);
            if (flagH && flagM && flagS)
            {
                if (h >= 0 && h <= 23 && m >= 0 && m <= 59 && s >= 0 && s <= 59)
                {
                    this.Hours = (byte)h;
                    this.Minutes = (byte)m;
                    this.Seconds = (byte)s;
                }
                else
                    throw new FormatException("expected format hh:mm:ss (0-23:0-59:0-59)");
            }
            else
                throw new FormatException("expected format hh:mm:ss (0-23:0-59:0-59)");

        }
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        public bool Equals(Time other) => (Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds);
        public override bool Equals(object obj)
        {
            return obj is Time ? Equals((Time)obj) : false;
        }
        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();
        public static bool Equals(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }

        public int CompareTo(Time other)
        {
            if (Hours != other.Hours)
                return Hours.CompareTo(other.Hours);
            if (Minutes != other.Minutes)
                return Minutes.CompareTo(other.Minutes);
            return Seconds.CompareTo(other.Seconds);
        }
        public static bool operator ==(Time t1, Time t2) => Equals(t1, t2);
        public static bool operator !=(Time t1, Time t2) => !(t1 == t2);
        public static bool operator <(Time t1, Time t2)
        {
            int val = t1.CompareTo(t2);
            if (val < 0)
                return true;
            else
                return false;
        }
        public static bool operator <=(Time t1, Time t2)
        {
            int val = t1.CompareTo(t2);
            if (val <= 0)
                return true;
            else
                return false;
        }
        public static bool operator >(Time t1, Time t2)
        {
            int val = t1.CompareTo(t2);
            if (val > 0)
                return true;
            else
                return false;
        }
        public static bool operator >=(Time t1, Time t2)
        {
            int val = t1.CompareTo(t2);
            if (val >= 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Can be applied only to type Time and TimePeriod, returns new Time which is equal to old Time after adding TimePeriod
        /// </summary>
        /// <param name="t"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static Time operator +(Time t, TimePeriod tp) => t.AddTimePeriod(tp);
        /// <summary>
        /// Can be applied only to type Time and TimePeriod, returns new time which is equal to inputed Time turned back by inputed amount of TimePeriod
        /// </summary>
        /// <param name="t"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static Time operator -(Time t, TimePeriod period) => t.SubstractTimePeriod(period);

        private long[] ReturnPeriodValuesIn24HSystem(ulong period)
        {
            long[] values = new long[3];
            values[0] = (long)(period / 3600);
            values[1] = (long)((period / 60) % 60);
            values[2] = (long)(period % 60);
            return values;
        }
        /// <summary>
        /// Returns Time after passing inputed TimePeriod
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public Time AddTimePeriod(TimePeriod period)
        {
            ulong currentTimeValue = (ulong)(Hours * 3600) + (ulong)(Minutes * 60) + Seconds;
            currentTimeValue += (ulong)period.PeriodInSeconds;
            long[] values = ReturnPeriodValuesIn24HSystem(currentTimeValue);

            byte h = (byte)(values[0] % 24);
            byte m = (byte)(values[1]);
            byte s = (byte)(values[2]);
            return new Time(h, m, s);
        }
        /// <summary>
        /// Returns new Time which is equal to old Time after inputed TimePeriod passed
        /// </summary>
        /// <param name="t"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static Time AddTimePeriod(Time t, TimePeriod period) => t.AddTimePeriod(period);
        /// <summary>
        /// Returns new time which is equal to Time turned back by inputed amount of TimePeriod
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public Time SubstractTimePeriod(TimePeriod period)
        {

            byte hoursToTurnBack = (byte)((period.PeriodInSeconds / 3600) % 24);
            byte minutesToTurnBack = (byte)((period.PeriodInSeconds / 60) % 60);
            byte secondsToTurnBack = (byte)(period.PeriodInSeconds % 60);
            int currentTimeInSeconds = Hours * 3600 + Minutes * 60 + Seconds;
            int prevTimeInSeconds = hoursToTurnBack * 3600 + minutesToTurnBack * 60 + secondsToTurnBack;
            int time;
            int defaultTime = 24 * 3600;
            byte h, m, s;
            if (currentTimeInSeconds > prevTimeInSeconds)
            {
                time = currentTimeInSeconds - prevTimeInSeconds;
                h = (byte)(time / 3600);
                m = (byte)((time / 60) % 60);
                s = (byte)(time % 60);
                return new Time(h, m, s);
            }
            else if (prevTimeInSeconds > currentTimeInSeconds)
            {
                time = defaultTime - Math.Abs(prevTimeInSeconds - currentTimeInSeconds);
                h = (byte)(time / 3600);
                m = (byte)((time / 60) % 60);
                s = (byte)(time % 60);
                return new Time(h, m, s);
            }
            else
                return new Time();
            
        }
        /// <summary>
        /// Returns new time which is equal to inputed Time turned back by inputed amount of TimePeriod
        /// </summary>
        /// <param name="t"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static Time SubstractTimePeriod(Time t, TimePeriod period) => t.SubstractTimePeriod(period);

    }
}
