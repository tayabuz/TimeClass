using System;
using System.Text.RegularExpressions;

namespace TimeClass
{
    public class Time
    {
        private int hours, minutes;
        private const int MAX_HOURS_IN_DAY = 24;
        private const int MAX_MINUTES_IN_DAY = 60;

        public Time(int h = 0, int m = 0)
        {
            if (!IsCorrect(h, m))  { throw new FormatException("Error: Time is uncorrect"); }
            hours = h;
            minutes = m;
        }

        private bool IsCorrect(int hours, int minutes)
        {
            if (hours < 0 || hours > MAX_HOURS_IN_DAY - 1) { return false; }
            if (minutes < 0 || minutes > MAX_MINUTES_IN_DAY - 1) { return false; }
            return true;
        }

        public static implicit operator string(Time ob1)
        {
            string result = ob1.hours + ":" + ob1.minutes;
            return result;
        }

        public static Time Parse(string s)
        {
            var CheckerFormatTime = Regex.Match(s, @"\d+\W+\d+");
            if (!CheckerFormatTime.Success)  { throw new FormatException("Error: uncorrect string format");}
            var delimiter = Regex.Match(s, @"\W");
            int hours = Convert.ToInt32(s.Substring(0, delimiter.Index));
            int minutes = Convert.ToInt32(s.Substring(delimiter.Index + 1, s.Length - hours.ToString().Length - 1));
            Time result = new Time(hours, minutes);
            return result;
        }

        public static Time operator +(Time ob1, int a)
        {
            int minutes = ob1.minutes;
            Time result;
            minutes += a;
            if (minutes > MAX_MINUTES_IN_DAY - 1)
            {
                int hours = ob1.hours + minutes / MAX_MINUTES_IN_DAY;
                minutes = minutes % MAX_MINUTES_IN_DAY;
                result = new Time(hours, minutes);
                return result;
            }
            result = new Time(ob1.hours, minutes);
            return result;
        }

        public static bool operator ==(Time ob1, Time ob2)
        {
            if (ob1.hours == ob2.hours && ob1.minutes == ob2.minutes) { return true; }
            return false;
        }
        public static bool operator !=(Time ob1, Time ob2)
        {
            return !(ob1 == ob2);
        }

        public static Time operator -(Time ob1, Time ob2)
        {
            Time result = new Time();
            int minutes = 0;
            int hours = 0;
            Time ob2Copy = ob2;
            if(ob1.hours < ob2.hours) { throw new FormatException("Error: Time1 - Time2: invalid time (hours < 0)");}
            while (ob2Copy != ob1)
            {
                ob2Copy = ob2Copy + 1;
                minutes++;
            }
            if (minutes > MAX_MINUTES_IN_DAY - 1)
            {
                hours = ob1.hours + minutes / MAX_MINUTES_IN_DAY;
                minutes = minutes % MAX_MINUTES_IN_DAY;
            }
            result = new Time(hours, minutes);
            return result;
        }
    }
}

