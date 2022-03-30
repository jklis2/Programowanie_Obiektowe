using System;
using System.Collections.Generic;
using System.Text;
using TimeLib;

namespace Time_TimePeriod
{
    /// <summary>
    ///  The Time structure.
    ///  Contains operators oveloadings and methods for arithmetic operations on Time strucure.
    /// </summary>
    /// <remarks>
    /// This struct can add, subtract and multiply.
    /// </remarks>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public readonly byte Hours;
        public byte hours => Hours;
        public readonly byte Minutes;
        public byte minutes => Minutes;
        public readonly byte Seconds;
        public byte seconds => Seconds;

        /// <summary>
        /// Constructor of Time
        /// </summary>
        /// <param name="hours"> A 64bit integer. </param>
        /// <param name="minutes"> A 64bit integer. </param>
        /// <param name="seconds"> A 64bit integer. </param>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when parameter 'hours' is greater than 24 
        /// or when parameters 'minutes' or 'seconds' are greater than 60</exception>
        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            if ((hours >= 24 || minutes >= 60 || seconds >= 60))
                throw new ArgumentOutOfRangeException();

            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        /// <summary>
        /// Splits a string and assigns values to Time
        /// </summary>
        /// <param name="time"> A Time structure. </param>
        /// /// <exception cref="System.ArgumentOutOfRangeException">Thrown when parameter 'h' is greater than 24 or when parameters
        /// 'm' or 's' are greater than 60</exception>
        public Time(string time)
        {
            string[] timeUnits = time.Split(':');

            byte h = Convert.ToByte(timeUnits[0]);
            byte m = Convert.ToByte(timeUnits[1]);
            byte s = Convert.ToByte(timeUnits[2]);
            if (h >= 24 || m >= 60 || s >= 60)
            {
                throw new ArgumentOutOfRangeException();
            }

            Hours = h;
            Minutes = m;
            Seconds = s;
        }

        /// <summary>
        /// Overides ToString method and returns a string.
        /// </summary>
        /// <returns>
        /// String with a hh:mm:ss format.
        /// </returns>
        public override string ToString()
        {
            return $"{Hours:00}:{Minutes:00}:{Seconds:00}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj) => (obj is Time time && Equals(time));

        public bool Equals(Time other) =>
            Hours.Equals(other.Hours) &&
            Minutes.Equals(other.Minutes) &&
            Seconds.Equals(other.Seconds);
        public override int GetHashCode()
        {
            return hours.GetHashCode() * minutes.GetHashCode() * seconds.GetHashCode();
        }

        public int CompareTo(Time other) => CompareByHours(other);

        public int CompareByHours(Time other)
        {
            if (this.Hours == other.Hours) return CompareByMinutes(other);
            return this.Hours > other.Hours ? 1 : -1;
        }

        public int CompareByMinutes(Time other)
        {
            if (this.Minutes == other.Minutes) return CompareBySeconds(other);
            return this.Minutes > other.Minutes ? 1 : -1;
        }

        public int CompareBySeconds(Time other)
        {
            if (this.Seconds == other.Seconds) return 0;
            return this.Seconds > other.Seconds ? 1 : -1;
        }


        public static bool operator ==(Time t1, Time t2) => t1.Equals(t2);
        public static bool operator !=(Time t1, Time t2) => !t1.Equals(t2);
        public static bool operator <(Time t1, Time t2) => t1.CompareTo(t2) < 0;
        public static bool operator >(Time t1, Time t2) => t1.CompareTo(t2) > 0;
        public static bool operator <=(Time t1, Time t2) => t1.CompareTo(t2) <= 0;
        public static bool operator >=(Time t1, Time t2) => t1.CompareTo(t2) >= 0;

        /// Adds two Time structures and returns new Time
        /// <summary>
        /// Adds Time <paramref name="t1"/> and Time <paramref name="t2"/> and returns new Time
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>
        /// The sum of two Time structures.
        /// </returns>
        public static Time operator +(Time t1, Time t2)
        {
            int h = t1.Hours + t2.Hours;
            int m = t1.Minutes + t2.Minutes;
            int s = t1.Seconds + t2.Seconds;

            int finalSeconds = s % 60;
            int minuteToAdd = s / 60;
            int finalMinutes = (m + minuteToAdd) % 60;
            int hourToAdd = (m + minuteToAdd) / 60;
            int finalHours = (h + hourToAdd) % 24;
            return new Time((byte)finalHours, (byte)finalMinutes, (byte)finalSeconds);
        }

        /// Subtracts two Time structures and returns new Time
        /// <summary>
        /// Subtracts Time <paramref name="t1"/> from Time <paramref name="t2"/> and returns new Time
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>
        /// The difference between two Time structures as a new Time.
        /// </returns>
        public static Time operator -(Time t1, Time t2)
        {
            int h = t1.Hours - t2.Hours;
            int m = t1.Minutes - t2.Minutes;
            int s = t1.Seconds - t2.Seconds;
            if (s < 0)
            {
                m--;
                s += 60;
            }
            if (m < 0)
            {
                h--;
                m += 60;
            }
            if (h < 0) h = 24 + h;
            return new Time((byte)h, (byte)m, (byte)s);

        }

        /// Multiplies a Time with an integer and returns a new Time
        /// <summary>
        /// Multiplies a Time with an integer and returns a new Time
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="a"></param>
        /// <returns>
        /// The product of Time and an integer.
        /// </returns>
        public static Time operator *(Time t1, int a)
        {
            int h = Convert.ToInt32(t1.hours) * a;
            int m = Convert.ToInt32(t1.minutes) * a;
            int s = Convert.ToInt32(t1.seconds) * a;

            int finalSeconds = s % 60;
            int minuteToAdd = s / 60;
            int finalMinutes = (m + minuteToAdd) % 60;
            int hourToAdd = (m + minuteToAdd) / 60;
            int finalHours = (h + hourToAdd) % 24;
            return new Time((byte)finalHours, (byte)finalMinutes, (byte)finalSeconds);
        }

        /// Adds timePeriod to already existing Time and returns new Time
        /// <summary>
        /// Adds timePeriod <paramref name="timePeriod"/> to already existing Time and returns new Time
        /// </summary>
        /// <param name="timePeriod"> A TimePeriod structure. </param>
        /// <returns>
        /// The sum of Time and TimePeriod
        /// </returns>
        public Time Plus(TimePeriod timePeriod)
        {
            Time time = new Time((byte)(timePeriod.Hours % 24), (byte)(timePeriod.Minutes), (byte)(timePeriod.Seconds));
            Time finalTime = this + time;
            return finalTime;
        }

        /// Adds time to timePeriod and returns new Time
        /// <summary>
        /// Adds time <paramref name="time"/> to timePeriod <paramref name="timePeriod"/> and returns new Time
        /// </summary>
        /// <param name="time"> A Time structure. </param>
        /// <param name="timePeriod"> A TimePeriod structure. </param>
        /// <returns>
        /// The sum of Time and TimePeriod
        /// </returns>
        public static Time Plus(Time time, TimePeriod timePeriod)
        {
            Time time2 = new Time((byte)(timePeriod.Hours % 24), (byte)(timePeriod.Minutes), (byte)(timePeriod.Seconds));
            Time finalTime = time2 + time;
            return finalTime;
        }

        /// Subtracts timePeriod from already existing Time and returns new Time
        /// <summary>
        /// Subtracts timePeriod <paramref name="timePeriod"/> from already existing Time and returns new Time
        /// </summary>
        /// <param name="timePeriod"> A TimePeriod structure. </param>
        /// <returns>
        /// The difference between Time and TimePeriod
        /// </returns>
        public Time Minus(TimePeriod timePeriod)
        {
            Time time = new Time((byte)(timePeriod.Hours % 24), (byte)(timePeriod.Minutes), (byte)(timePeriod.Seconds));
            Time finalTime = this - time;
            return finalTime;
        }

        /// Subtracts timePeriod from time and returns new Time
        /// <summary>
        /// Subtracts timePeriod <paramref name="timePeriod"/> from time <paramref name="time"/> and returns new Time
        /// </summary>
        /// <param name="time"> A Time structure. </param>
        /// <param name="timePeriod"> A TimePeriod structure. </param>
        /// <returns>
        /// The difference between Time and TimePeriod
        /// </returns>
        public static Time Minus(Time time, TimePeriod timePeriod)
        {
            Time time2 = new Time((byte)(timePeriod.Hours % 24), (byte)(timePeriod.Minutes), (byte)(timePeriod.Seconds));
            Time finalTime = time - time2;
            return finalTime;
        }

        /// Multiplies already existing Time with an integer and returns new Time
        /// <summary>
        /// Multiplies already existing Time with an integer <paramref name="a"/> and returns new Time
        /// </summary>
        /// <param name="a"> An integer. </param>
        /// <returns>
        /// The product of Time and integer
        /// </returns>
        public Time Multiply(int a)
        {
            Time finalTime = this * a;
            return finalTime;
        }
    }

}    
