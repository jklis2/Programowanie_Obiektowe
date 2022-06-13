using System;
using System.Linq;

namespace Linq_To_Object_Płyta_CD
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = Console.ReadLine();
            var query = entry.Split(',')
                .Select(x => x.Split(':'))
                .Select(x => Convert.ToInt32(x[0]) * 60 + Convert.ToInt32(x[1]));

            int srednia = Convert.ToInt32(Math.Ceiling(query.Average()));
            int suma = Convert.ToInt32(query.Sum());

            Console.WriteLine($"{query.Count()} {Converter(srednia)} {Converter(suma)}");
        }

        static string Converter(int wejscie)
        {
            int h = 0;
            int m = 0;
            int s = 0;
            if (wejscie >= 60)
            {
                m = wejscie / 60;
                s = wejscie % 60;
                if (m >= 60)
                {
                    h = m / 60;
                    m = m % 60;
                }
            }
            else
            {
                s = wejscie;
            }

            string wyj = (h != 0 ? h.ToString() : null) + (h != 0 ? ":" : null) + m.ToString(h != 0 ? "00" : "0") + ":" + s.ToString("00");
            return wyj;
        }
    }
}
