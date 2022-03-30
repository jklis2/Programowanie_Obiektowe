using System;
using System.Collections.Generic;
using System.Text;
using Time_TimePeriod;

namespace TimeLib
{
    /// <summary>
    /// The TimePeriod structure
    /// Contains operators oveloadings and methods for arithmetic operations on TimePeriod strucure.
    /// </summary>
    /// <remarks>
    /// This structure can add, subtract and multiply.
    /// </remarks>
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private readonly long periodInSec;
        public long PeriodInSec => periodInSec;
        private readonly long hours;
        public long Hours => hours;
        private readonly long minutes;
        public long Minutes => minutes;
        private readonly long seconds;
        public long Seconds => seconds;

        /// <summary>
        /// Constructor of TimePeriod
        /// </summary>
        /// <param name="hours"> A 64bit integer. </param>
        /// <param name="minutes"> A 64bit integer. </param>
        /// <param name="seconds"> A 64bit integer. </param>
        ///  <exception cref="ArgumentOutOfRangeException"> Thrown when one or more
        ///  parameters are less than 0 or when parameter 'minutes' or 'seconds' are more than 60</exception>
        public TimePeriod(long hours = 0, long minutes = 0, long seconds = 0)
        {
            if (hours < 0 || minutes < 0 || seconds < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (minutes > 60 || seconds > 60)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;

            long getSecFromHours = hours * 3600;
            long getSecFromMins = minutes * 60;

            periodInSec = getSecFromHours + getSecFromMins + seconds;
        }

        /// <summary>
        /// Constructor of TimePeriod with two parmaters of Time structure
        /// </summary>
        /// <param name="t1"> A Time structure. </param>
        /// <param name="t2"> A Time structure. </param>
        public TimePeriod(Time t1, Time t2)
        {
            Time t = t1 - t2;
            hours = t.hours;
            minutes = t.minutes;
            seconds = t.seconds;

            periodInSec = (hours * 3600) + (minutes * 60) + seconds;
        }

        /// <summary>
        /// Splits string and assigns values to TimePeriod
        /// </summary>
        /// <param name="timePeriod"> A TimePeriod structure. </param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when one or more parameters
        /// are less than 0 or when parameter 'minutes' or 'seconds' are greater than 60</exception>
        public TimePeriod(string timePeriod)
        {
            string[] timeUnits = timePeriod.Split(':');

            long h = Convert.ToInt64(timeUnits[0]);
            long m = Convert.ToInt64(timeUnits[1]);
            long s = Convert.ToInt64(timeUnits[2]);
            if (h < 0 || m < 0 || s < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (m > 60 || s > 60)
            {
                throw new ArgumentOutOfRangeException();
            }

            hours = h;
            minutes = m;
            seconds = s;

            periodInSec = (hours * 3600) + (minutes * 60) + seconds;

        }

        /// <summary>
        /// Overides ToString method and returns a string.
        /// </summary>
        /// <returns>
        /// String with a h:mm:ss format.
        /// </returns>
        public override string ToString()
        {
            return $"{hours:0}:{minutes:00}:{seconds:00}";
        }

        public override bool Equals(Object obj) => (obj is TimePeriod timePeriod && Equals(timePeriod));

        public bool Equals(TimePeriod other) =>
            Hours.Equals(other.Hours) &&
            Minutes.Equals(other.Minutes) &&
            Seconds.Equals(other.Seconds);

        public override int GetHashCode()
        {
            return hours.GetHashCode() + minutes.GetHashCode() + seconds.GetHashCode() + periodInSec.GetHashCode();
        }
        public int CompareTo(TimePeriod other) => CompareByHours(other);

        public int CompareByHours(TimePeriod other)
        {
            if (this.Hours == other.Hours) return CompareByMinutes(other);
            return this.Hours > other.Hours ? 1 : -1;
        }

        public int CompareByMinutes(TimePeriod other)
        {
            if (this.Minutes == other.Minutes) return CompareBySeconds(other);
            return this.Minutes > other.Minutes ? 1 : -1;
        }

        public int CompareBySeconds(TimePeriod other)
        {
            if (this.Seconds == other.Seconds) return 0;
            return this.Seconds > other.Seconds ? 1 : -1;
        }

        public static bool operator ==(TimePeriod tP1, TimePeriod tP2) => tP1.Equals(tP2);
        public static bool operator !=(TimePeriod tP1, TimePeriod tP2) => !tP1.Equals(tP2);
        public static bool operator <(TimePeriod tP1, TimePeriod tP2) => tP1.CompareTo(tP2) < 0;
        public static bool operator >(TimePeriod tP1, TimePeriod tP2) => tP1.CompareTo(tP2) > 0;
        public static bool operator <=(TimePeriod tP1, TimePeriod tP2) => tP1.CompareTo(tP2) <= 0;
        public static bool operator >=(TimePeriod tP1, TimePeriod tP2) => tP1.CompareTo(tP2) >= 0;


        /// Adds two TimePeriod structures and returns new TimePeriod
        /// <summary>
        /// Adds TimePeriod <paramref name="tP1"/> and TimePeriod <paramref name="tP2"/> and returns new TimePeriod
        /// </summary>
        /// <param name="tP1"></param>
        /// <param name="tP2"></param>
        /// <returns>
        /// The sum of two TimePeriod structures.
        /// </returns>
        public static TimePeriod operator +(TimePeriod tP1, TimePeriod tP2)
        {
            long h = tP1.hours + tP2.hours;
            long m = tP1.minutes + tP2.minutes;
            long s = tP1.seconds + tP2.seconds;

            long finalSeconds = s % 60;
            long minuteToAdd = s / 60;
            long finalMinutes = (m + minuteToAdd) % 60;
            long hourToAdd = (m + minuteToAdd) / 60;
            long finalHours = h + hourToAdd;

            return new TimePeriod(finalHours, finalMinutes, finalSeconds);
        }

        /// Subtracts two TimePeriod structures and returns new TimePeriod 
        /// <summary>
        /// Subtracts TimePeriod <paramref name="tP1"/> and TimePeriod <paramref name="tP2"/> and returns new TimePeriod 
        /// </summary>
        /// <param name="tP1"></param>
        /// <param name="tP2"></param>
        /// <returns>
        /// The difference between two TimePeriod structures.
        /// </returns>
        public static TimePeriod operator -(TimePeriod tP1, TimePeriod tP2)
        {
            long h, m, s;
            if (tP1.CompareTo(tP2) > tP2.CompareTo(tP1))
            {
                h = tP1.hours - tP2.hours;
                m = tP1.minutes - tP2.minutes;
                s = tP1.seconds - tP2.seconds;
            }
            else
            {
                h = tP2.hours - tP1.hours;
                m = tP2.minutes - tP1.minutes;
                s = tP2.seconds - tP1.seconds;
            }

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
            if (h < 0) h += h;

            return new TimePeriod(h, m, s);
        }

        /// Multiplies a TimePeriod with an integer and returns a new TimePeriod
        /// <summary>
        /// Multiplies a TimePeriod <paramref name="tP1"/> with an integer <paramref name="a"/> and returns a new TimePeriod
        /// </summary>
        /// <param name="tP1"></param>
        /// <param name="a"></param>
        /// <returns>
        /// The product of TimePeriod and an integer.
        /// </returns>
        public static TimePeriod operator *(TimePeriod tP1, int a)
        {
            long h = tP1.hours * a;
            long m = tP1.minutes * a;
            long s = tP1.seconds * a;

            long finalSeconds = s % 60;
            long minuteToAdd = s / 60;
            long finalMinutes = (m + minuteToAdd) % 60;
            long hourToAdd = (m + minuteToAdd) / 60;
            long finalHours = h + hourToAdd;

            return new TimePeriod(finalHours, finalMinutes, finalSeconds);
        }

        /// Adds timePeriod to already existing TimePeriod and returns new TimePeriod
        /// <summary>
        /// Adds timePeriod <paramref name="timePeriod"/> to already existing TimePeriod and returns new TimePeriod
        /// </summary>
        /// <param name="timePeriod"> A TimePeriod structure. </param>
        /// <returns>
        /// The sum of two TimePeriod structures
        /// </returns>
        public TimePeriod Plus(TimePeriod timePeriod)
        {
            TimePeriod finalTimePeriod = this + timePeriod;
            return finalTimePeriod;
        }

        /// Adds TimePeriod to another TimePeriod and returns new TimePeriod
        /// <summary>
        /// Adds TimePeriod <paramref name="tP1"/> to another TimePeriod <paramref name="tP2"/> and returns new TimePeriod
        /// </summary>
        /// <param name="tP1"> A TimePeriod structure. < /param>
        /// <param name="tP2"> A TimePeriod structure. </param>
        /// <returns>
        /// The sum of two TimePeriod structures
        /// </returns>
        public static TimePeriod Plus(TimePeriod tP1, TimePeriod tP2)
        {
            TimePeriod finalTimePeriod = tP1 + tP2;
            return finalTimePeriod;
        }

        /// Subtracts timePeriod from already existing TimePeriod and returns new TimePeriod
        /// <summary>
        /// Subtracts timePeriod <paramref name="timePeriod"/> from already existing TimePeriod and returns new TimePeriod
        /// </summary>
        /// <param name="timePeriod"> A TimePeriod structure. </param>
        /// <returns>
        /// The difference between two TimePeriod structurs
        /// </returns>
        public TimePeriod Minus(TimePeriod timePeriod)
        {
            TimePeriod finalTimePeriod = this - timePeriod;
            return finalTimePeriod;
        }

        /// Subtracts TimePeriod from another TimePeriod and returns new TimePeriod
        /// <summary>
        /// Subtracts TimePeriod <paramref name="tP1"/> from another TimePeriod <paramref name="tP2"/> and returns new TimePeriod
        /// </summary>
        /// <param name="tP1"> A TimePeriod structure. </param>
        /// <param name="tP2"> A TimePeriod structure. </param>
        /// <returns>
        /// The difference between two TimePeriod structures
        /// </returns>
        public static TimePeriod Minus(TimePeriod tP1, TimePeriod tP2)
        {
            TimePeriod finalTimePeriod = tP1 - tP2;
            return finalTimePeriod;
        }

        /// Multiplies an already existing TimePeriod with an integer and returns new TimePeriod
        /// <summary>
        /// Multiplies an already existing TimePeriod with an integer <paramref name="a"/> and returns new TimePeriod
        /// </summary>
        /// <param name="a"> An integer. </param>
        /// <returns>
        /// The product of TimePeriod and an integer
        /// </returns>
        public TimePeriod Multiply(int a)
        {
            TimePeriod finalTimePeriod = this * a;
            return finalTimePeriod;
        }
    }
}

