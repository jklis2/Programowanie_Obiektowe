using PudelkoLib;
using System;
using System.Collections.Generic;

namespace Zadanie_Pudelko
{
    /*
    Funkcje oraz właściwości metod rozszerzających
    - jest to metoda statyczna;
    - musi być umieszczona w klasie statycznej;
    - wykorzystuje słowo kluczowe this jako pierwszy parametr z typem zdefiniowanym w środowisku .NET;
    */

    static class Program
    {
        public static Pudelko Kompresuj(this Pudelko p)
        {
            double a = Math.Pow(p.Objetosc, (1 / 3D)); //D - decimal
            return new Pudelko(a, a, a);
        }

        static void Main(string[] args)
        {
            //W funkcji Main programu głównego (aplikacja konsolowa) utwórz listę kliku różnych pudełek, używając różnych wariantów konstruktora.
            //Wypisz pudełka umieszczone na liście(po jednym w wierszu).
            List<Pudelko> pudelko = new List<Pudelko>();
            pudelko.Add(new Pudelko(2.5, 2.5, 2.5));
            pudelko.Add(new Pudelko(2.25, 2.5, 6.75));
            pudelko.Add(new Pudelko(6.66, 3.33, 3.33));
            pudelko.Add(new Pudelko(10, 2.5, 2, UnitOfMeasure.centimeter));
            pudelko.Add(new Pudelko(10, 2, 5, UnitOfMeasure.centimeter));
            pudelko.Add(new Pudelko(5, 5, 5, UnitOfMeasure.centimeter));
            pudelko.Add(new Pudelko(1000, 2000, 1000, UnitOfMeasure.milimeter));
            pudelko.Add(new Pudelko(997, 998, 999, UnitOfMeasure.milimeter));
            pudelko.Add(new Pudelko(3, 3, 3, UnitOfMeasure.centimeter));
            pudelko.Add(new Pudelko(2, 2, 2));

            Console.WriteLine("Wartości boków\n");
            foreach (var pudelka in pudelko)

                Console.WriteLine($"\t{pudelka} \t  [OBJĘTOŚĆ] {pudelka.Objetosc} || [POLE CAŁKOWITE] {pudelka.Pole} || [SUMA BOKÓW] {pudelka.Bok}");
            Console.WriteLine("\n\nPOSORTOWANE DANE\n");
            // Posortuj tę listę według następującego kryterium: p1 poprzedza p2

            pudelko.Sort(delegate (Pudelko x, Pudelko y)
            {
                if (x.Objetosc < y.Objetosc)
                {
                    return -1;
                }
                else if (x.Objetosc == y.Objetosc)
                    if (x.Pole < y.Pole)
                        return -1;
                    else if (x.Pole == y.Pole)
                        if (x.Bok < y.Bok)
                            return -1;
                        else
                            return 1;
                    else
                        return 1;
                else
                    return 1;
            });
            Console.WriteLine("Wartości boków\n");
            foreach (var pudelka in pudelko)
                Console.WriteLine($"\t{pudelka} \t  [OBJĘTOŚĆ] {pudelka.Objetosc} || [POLE CAŁKOWITE] {pudelka.Pole} || [SUMA BOKÓW] {pudelka.Bok}");
        }
    }
}