﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    /// <summary>
    /// Time struct constructor needs at least one input value, otherwise auto generated constructor will be called and fields would be filled by default values (0)
    /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte hours, minutes, seconds;
        ///<value>Gets number of hours in Time struct</value>
        public byte Hours => hours;
        ///<value>Gets number of minutes in Time struct</value>
        public byte Minutes => minutes;
        ///<value>Gets number of seconds in Time struct</value>
        public byte Seconds => seconds;
        public Time(byte hours)
        {
            if(hours > 23 || hours < 0)
                throw new Exception("input value out of range");
            this.hours = hours;
            this.minutes = 0;
            this.seconds = 0;
        }
        public Time(byte hours, byte minutes)
        {
            if (hours > 23 || hours < 0)
                throw new Exception("input value out of range");
            if(minutes > 59 || minutes <0)
                throw new Exception("input value out of range");
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = 0;
        }
        /// <summary>
        /// Correct range of input values is: hours: 0-23; minutes 0-59; seconds: 0-59; passing values out of range will cause exception to be thrown
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public Time(byte hours, byte minutes, byte seconds)
        {
            this.hours = verify(hours, 0, 23);
            this.minutes = verify(minutes, 0, 59);
            this.seconds = verify(seconds, 0, 59);
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
                    this.hours = (byte)h;
                    this.minutes = (byte)m;
                    this.seconds = (byte)s;
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

        public static Time operator +(Time t1, Time t2)
        {

        }
        public static Time operator -(Time t1, Time t2)
        {

        }
        //Time AddTimePeriod(TimePeriod period)
        //{

        //}
        //static Time AddTimePeriod(Time t, TimePeriod period)
        //{

        //}
        //Time SubstractTimePeriod(TimePeriod period)
        //{

        //}
        //static Time SubstractTimePeriod(Time t, TimePeriod period)
        //{

        //}
    }
}
