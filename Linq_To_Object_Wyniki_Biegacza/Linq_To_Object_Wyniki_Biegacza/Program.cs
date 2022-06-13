using System;
using System.Linq;

namespace Linq_To_Object_Wyniki_Biegacza
{
    public class Program
    {
        static int Count() => throw new NotImplementedException();

        static void Main(string[] args)
        {
            string testCase = Console.ReadLine();
            string data = Console.ReadLine();
            var query = data.Split(',')
            .Select(x => x.Split(':'))
            .Select(x => Convert.ToInt32(x[0]) * 60 + Convert.ToInt32(x[1])).ToList();
            string wyjscie = "";
            int[] separateArr = new int[query.Count()];

            for (int i = 0; i < query.Count(); i++)
            {
                if (i == 0)
                {
                    separateArr[i] = query[i];
                }
                else
                {
                    separateArr[i] = query[i] - query[i - 1];
                }
            }

            switch (testCase)
            {
                case "test1":
                    Console.WriteLine(query.Count());
                    break;
                case "test2":
                    wyjscie = "";
                    foreach (var item in separateArr)
                    {
                        wyjscie = wyjscie + Converter(item) + " ";
                    }
                    Console.WriteLine(wyjscie.Trim());
                    break;
                case "test3":
                    int minTime = separateArr.Min();
                    wyjscie = "";
                    wyjscie = wyjscie + Converter(minTime) + " ";

                    for (int i = 0; i < separateArr.Count(); i++)
                    {
                        if (separateArr[i] == minTime)
                        {
                            wyjscie = wyjscie + (i + 1).ToString() + " ";
                        }
                    }
                    Console.WriteLine(wyjscie.Trim());
                    break;
                case "test4":
                    int maxTime = separateArr.Max();
                    wyjscie = "";
                    wyjscie = wyjscie + Converter(maxTime) + " ";

                    for (int i = 0; i < separateArr.Count(); i++)
                    {
                        if (separateArr[i] == maxTime)
                        {
                            wyjscie = wyjscie + (i + 1).ToString() + " ";
                        }
                    }
                    Console.WriteLine(wyjscie.Trim());
                    break;
                case "test5":
                    int srednia = Convert.ToInt32(Math.Ceiling(separateArr.Average()));
                    Console.WriteLine(Converter(srednia));
                    break;
            }
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

            string wyj = (h != 0 ? h.ToString() : null) + (h != 0 ? ":" : null) + m.ToString("00") + ":" + s.ToString("00");
            return wyj;
        }

    }
}
