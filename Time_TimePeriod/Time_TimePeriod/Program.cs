using System;
using System.Collections.Generic;
using TimeLib;

namespace Time_TimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------- Time list --------------");
            List<Time> times = new List<Time>();
            times.Add(new Time(8, 30));
            times.Add(new Time(11, 23, 6));
            times.Add(new Time(22, 46, 59));
            times.Add(new Time(1, 1, 1));
            times.Add(new Time(13, 18, 30));
            times.Add(new Time(2));
            times.Add(new Time(2));

            foreach (var time in times)
            {
                Console.WriteLine($"Time: {time}");
            }

            Console.WriteLine("----------------------------------------");

            Time t1 = new Time(2, 35, 30);
            Console.WriteLine($"Time t1: {t1}");

            Time t2 = new Time(14, 10, 10);
            Console.WriteLine($"Time t2: {t2}");


            Console.WriteLine(t1.Equals(t2));

            Console.WriteLine("------ Plus and minus operations -------");

            Console.WriteLine($"Sum of t1 and t2: {t1 + t2}");
            Console.WriteLine($"Subtraction of t1 and t2: {t1 - t2}");

            Time t3 = new Time(11, 23, 6);
            Time t4 = new Time(13, 18, 30);

            Console.WriteLine($"Sum of t3 and t4: {t3 + t4}");
            Console.WriteLine($"Subtraction of t3 and t4: {t3 - t4}");

            Console.WriteLine($"Sum of t[1] and t[4]: {times[1] + times[4]}");
            Console.WriteLine($"Subtraction of t[1] and t[4]: {times[1] - times[4]}");
            Console.WriteLine($"Subtraction of t[5]={times[5]} and t[6]={times[6]}: {times[5] - times[6]}");

            Time t5 = new Time("09:05:59");
            Console.WriteLine(t5);

            Console.WriteLine("-------------- TimePeriod --------------");

            TimePeriod tP1 = new TimePeriod(new Time(12, 30), new Time(5, 30));
            Console.WriteLine($"TimePeriod: {tP1}");
            Console.WriteLine($"Period in seconds: {tP1.PeriodInSec} seconds");

            TimePeriod tP2 = new TimePeriod(new Time(5), new Time(14, 36, 08));
            Console.WriteLine($"TimePeriod: {tP2}");
            Console.WriteLine($"Period in seconds: {tP2.PeriodInSec} seconds");

            TimePeriod tP3 = new TimePeriod("129:45:06");
            Console.WriteLine(tP3);

            Console.WriteLine(tP1 + tP2);
            Console.WriteLine(tP1 - tP2);

            Console.WriteLine("------------- Time methods -------------");

            Console.WriteLine($"Time {t3} plus time period {tP2}: {t3.Plus(tP2)}");
        }
    }
}
