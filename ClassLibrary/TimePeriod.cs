using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private readonly long periodInSeconds;
        ///<value>Gets time period represented in seconds</value>
        public long PeriodInSeconds => periodInSeconds;
        /// <summary>
        /// Passed value must be between 0 and 9,223,372,036,854,775,807; otherwise exception will be thrown
        /// </summary>
        /// <param name="seconds"></param>
        public TimePeriod(long seconds)
        {
            if (seconds < 0)
                throw new Exception("value of seconds out of expected range");
            periodInSeconds = seconds;
        }
        /// <summary>
        /// Passed value must be in correct range: hours: 0-2147483647; minutes 0-59; otherwise exception will be thrown
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        public TimePeriod(int hours, int minutes)
        {
            if (hours < 0 || minutes < 0 || minutes > 59)
                throw new Exception("input values out of expected range");
            periodInSeconds = (hours * 3600) + (minutes * 60);
        }
        /// <summary>
        /// Passed value must be in correct range: hours: 0-2147483647; minutes 0-59; seconds: 0-59; otherwise exception will be thrown
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public TimePeriod(int hours, int minutes, int seconds)
        {
            if (hours < 0 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 59)
                throw new Exception("input values out of expected range");
            periodInSeconds = ((long)hours * 3600) + (minutes * 60) + seconds;
        }
        /// <summary>
        /// Generates time period between two Time statements
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        public TimePeriod(Time t1, Time t2)
        {
            int period1 = (t1.Hours * 3600) + (t1.Minutes * 60) + t1.Seconds;
            int period2 = (t2.Hours * 3600) + (t2.Minutes * 60) + t2.Seconds;
            if (period1 > period2)
                periodInSeconds = period1 - period2;
            else if (period2 > period1)
                periodInSeconds = period2 - period1;
            else
                periodInSeconds = 0;
        }
        /// <summary>
        /// Input string requires to be formatted like "hh:mm:ss" in range "hours: 0-2147483647; minutes: 0-59; seconds: 0-59", otherwise exception will be thrown
        /// </summary>
        /// <param name="input"></param>
        public TimePeriod(string input)
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
                if (h >= 0 && h <= int.MaxValue && m >= 0 && m <= 59 && s >= 0 && s <= 59)
                {
                    periodInSeconds = (h * 3600) + (m * 60) + s;
                }
                else
                    throw new FormatException("expected format hh:mm:ss (hours: 0-2147483647; minutes: 0-59; seconds: 0-59)");
            }
            else
                throw new FormatException("expected format hh:mm:ss (hours: 0-2147483647; minutes: 0-59; seconds: 0-59)");
        }
        public override string ToString() => $"{(PeriodInSeconds / 3600):D2}:{((PeriodInSeconds / 60) % 60):D2}:{(PeriodInSeconds % 60):D2}";

        public bool Equals(TimePeriod other) => (PeriodInSeconds == other.PeriodInSeconds);
        public override bool Equals(object obj) => obj is TimePeriod ? Equals((Time)obj) : false;
        public override int GetHashCode() => PeriodInSeconds.GetHashCode();
        public static bool Equals(TimePeriod t1, TimePeriod t2) => t1.Equals(t2);
        public int CompareTo(TimePeriod other) => PeriodInSeconds.CompareTo(other.PeriodInSeconds);
        public static bool operator ==(TimePeriod t1, TimePeriod t2) => Equals(t1, t2);
        public static bool operator !=(TimePeriod t1, TimePeriod t2) => !(t1 == t2);
        public static bool operator <(TimePeriod t1, TimePeriod t2) => (t1.CompareTo(t2) < 0);
        public static bool operator <=(TimePeriod t1, TimePeriod t2) => (t1.CompareTo(t2) <= 0);

        public static bool operator >(TimePeriod t1, TimePeriod t2) => (t1.CompareTo(t2) > 0);
        public static bool operator >=(TimePeriod t1, TimePeriod t2) => (t1.CompareTo(t2) >= 0);
        /// <summary>
        /// Returns new TimePeriod which value is equal to adding value of inputed TimePeriod to base TimePeriod, if final value is greater than 9,223,372,036,854,775,807 or is equal to 0 exception would be thrown
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TimePeriod operator +(TimePeriod t1, TimePeriod t2) => t1.Add(t2);
        /// <summary>
        /// Returns new TimePeriod which value is equal to substraction of inputed TimePeriod from base TimePeriod, if value of substraction is negative returned TimePeriod would have default value (00:00:00)
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TimePeriod operator -(TimePeriod t1, TimePeriod t2) => t1.Substract(t2);
        /// <summary>
        /// Returns new TimePeriod which value is equal to adding value of inputed TimePeriod to base TimePeriod, if final value is greater than 9,223,372,036,854,775,807 or is equal to 0 exception would be thrown
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public TimePeriod Add(TimePeriod other)
        {
            if ((PeriodInSeconds + other.PeriodInSeconds) <= 0)
                throw new Exception("Value out of expected range");
            else
                return new TimePeriod(PeriodInSeconds + other.PeriodInSeconds);
        }
        /// <summary>
        /// Returns new TimePeriod which value is equal to adding two TimePeriods, if value is greater than 9,223,372,036,854,775,807 or is equal to 0 exception would be thrown
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TimePeriod Add(TimePeriod t1, TimePeriod t2) => t1.Add(t2);
        /// <summary>
        /// Returns new TimePeriod which value is equal to substraction of inputed TimePeriod from base TimePeriod, if value of substraction is negative returned TimePeriod would have default value (00:00:00)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public TimePeriod Substract(TimePeriod other)
        {
            if ((PeriodInSeconds - other.PeriodInSeconds) > 0)
                return new TimePeriod(PeriodInSeconds - other.PeriodInSeconds);
            else
                return new TimePeriod();
        }
        /// <summary>
        /// Returns new TimePeriod which value is equal to substraction of lower TimePeriod from greater TimePeriod, if both are equal returned TimePeriod would have defualt value (00:00:00)
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TimePeriod Substract(TimePeriod t1, TimePeriod t2)
        {
            if (t1 > t2)
                return new TimePeriod(t1.PeriodInSeconds - t2.PeriodInSeconds);
            if (t2 > t1)
                return new TimePeriod(t2.PeriodInSeconds - t1.PeriodInSeconds);
            return new TimePeriod();
        }
        /// <summary>
        /// Multiplies TimePeriod by inputed multiplier, if output value is greater than 9,223,372,036,854,775,807 or multiplier is <= 0 returned TimePeriod would have default value (00:00:00)
        /// </summary>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public TimePeriod Multiply(int multiplier)
        {
            if ((PeriodInSeconds * multiplier) <= 0 || multiplier <= 0)
                return new TimePeriod();
            else
                return new TimePeriod(PeriodInSeconds * multiplier);

        }
        /// <summary>
        /// Multiplies inputed TimePeriod by inputed multiplier, if output value is greater than 9,223,372,036,854,775,807 or multiplier is <= 0 returned TimePeriod would have default value (00:00:00)
        /// </summary>
        /// <param name="t"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static TimePeriod Multiply(TimePeriod t, int multiplier) => t.Multiply(multiplier);
    }
}
