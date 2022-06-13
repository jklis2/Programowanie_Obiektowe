using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace PudelkoLib
{
    public enum UnitOfMeasure
    {
        milimeter,
        centimeter,
        meter
    }

    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable //sealed - zapieczętowanie klasy 
    {
        private readonly double a;
        private readonly double b;
        private readonly double c;

        #pragma warning disable IDE0052 // Usuń nieodczytywane składowe prywatne
        private readonly UnitOfMeasure unit;
        #pragma warning restore IDE0052 // Usuń nieodczytywane składowe prywatne

        public double Pole => Math.Round(2 * (a * b + a * c + b * c), 6);
        public double Objetosc => Math.Round(a * b * c, 9);
        public double Bok => a + b + c;
        public double A { get => a; }
        public double B { get => b; }
        public double C { get => c; }

        public double X = 0.1;
        public double Y = 0.1;
        public double Z = 0.1;

        public double LastN(double x)
        {
            return Math.Floor(x * 1000) / 1000;
        }

        public double Change(double a, UnitOfMeasure unit)
        {
            switch (unit)
            {
                case UnitOfMeasure.meter:
                    break;
                case UnitOfMeasure.centimeter:
                    a *= 0.01;
                    break;
                case UnitOfMeasure.milimeter:
                    a *= 0.001;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            double x = LastN(a);
            if (x <= 0 || a > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
            return a;
        }

        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            var check = unit switch
            {
                UnitOfMeasure.meter => 0.1,
                UnitOfMeasure.centimeter => 10,
                UnitOfMeasure.milimeter => 100,
                _ => throw new ArgumentOutOfRangeException(),
            };
            this.unit = unit;
            this.a = Change((a == null) ? check : (double)a, unit);
            this.b = Change((b == null) ? check : (double)b, unit);
            this.c = Change((c == null) ? check : (double)c, unit);
        }

        public override string ToString()
        {
            return string.Format($"{A:F3} m × {B:F3} m × {C:F3} m");
        }

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (formatProvider == null)
            {
                _ = CultureInfo.CurrentCulture;
            }
            if (format == null)
            {
                format = "m";
            }

            switch (format)
            {
                case "m":
                    return ToString();
                case "cm":
                    X = Math.Round(A * 100, 1);
                    Y = Math.Round(B * 100, 1);
                    Z = Math.Round(C * 100, 1);
                    return string.Format($"{X:F1} {format} × {Y:F1} {format} × {Z:F1} {format}");
                case "mm":
                    X = Math.Round(A * 1000);
                    Y = Math.Round(B * 1000);
                    Z = Math.Round(C * 1000);
                    return $"{X} {format} × {Y} {format} × {Z} {format}";
                default:
                    throw new FormatException();
            }
        }

        public bool Equals(Pudelko pud)
        {
            if (pud == null)
            {
                return false;
            }
            if (this.Objetosc == pud.Objetosc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Pudelko Obj = obj as Pudelko;
            if (Obj == null)
            {
                return false;
            }
            else
            {
                return Equals(Obj);
            }
        }

        public static bool operator ==(Pudelko p1, Pudelko p2)
        {
            if (((object)p1) == null || ((object)p2) == null)
            {
                return Object.Equals(p1, p2);
            }
            return p1.Equals(p2);
        }

        public static bool operator !=(Pudelko p1, Pudelko p2)
        {
            if (((object)p1) is null || ((object)p2) is null)
            {
                return !Object.Equals(p1, p2);
            }
            return !(p1.Equals(p2));
        }

        public static implicit operator Pudelko(ValueTuple<int, int, int> tuple)
        {
            return new Pudelko(tuple.Item1, tuple.Item2, tuple.Item3, UnitOfMeasure.milimeter);
        }

        public static explicit operator double[](Pudelko p)
        {
            double[] tablica = new double[3];
            tablica[0] = p.A;
            tablica[1] = p.B;
            tablica[2] = p.C;
            return tablica;
        }

        public override int GetHashCode()
        {
            return Objetosc.GetHashCode();
        }

        public double this[int i]
        {
            get
            {
                return i switch { 0 => this.A, 1 => this.B, 2 => this.C, _ => throw new ArgumentException() };
            }
        }

        public IEnumerator<double> GetEnumerator()
        {
            yield return A;
            yield return B;
            yield return C;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
 
        public static Pudelko Parse(string text)
        {
            double x, y, z;
            string[] p = text.Split(" ");
            UnitOfMeasure xxx;
            switch (p[1])
            {
                case "m":
                    x = double.Parse(p[0], CultureInfo.InvariantCulture);
                    y = double.Parse(p[3], CultureInfo.InvariantCulture);
                    z = double.Parse(p[6], CultureInfo.InvariantCulture);
                    xxx = UnitOfMeasure.meter;
                    break;
                case "mm":
                    x = double.Parse(p[0], CultureInfo.InvariantCulture);
                    y = double.Parse(p[3], CultureInfo.InvariantCulture);
                    z = double.Parse(p[6], CultureInfo.InvariantCulture);
                    xxx = UnitOfMeasure.milimeter;
                    break;
                case "cm":
                    x = double.Parse(p[0], CultureInfo.InvariantCulture);
                    y = double.Parse(p[3], CultureInfo.InvariantCulture);
                    z = double.Parse(p[6], CultureInfo.InvariantCulture);
                    xxx = UnitOfMeasure.centimeter;
                    break;
                default:
                    x = double.Parse(p[0], CultureInfo.InvariantCulture);
                    y = double.Parse(p[2], CultureInfo.InvariantCulture);
                    z = double.Parse(p[4], CultureInfo.InvariantCulture);
                    xxx = UnitOfMeasure.meter;
                    break;
            }
            return new Pudelko(x, y, z, xxx);
        }
    }
}