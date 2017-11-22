using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    TODO: zapis floty do pliku .xml
 */

namespace Wypozyczalnia
{
    class Flota
    {
        List<Samochod> samochody;

        public Flota(int wielkosc)
        {
            samochody = new List<Samochod>();
        }

        /// <summary>
        /// Procedura wprowadzenia nowego samochodu to tablicy
        /// </summary>
        public void Dodaj()
        {
            Console.Clear();
            Samochod s = new Samochod();
            Console.Write("Marka: ");
            s.Marka = Console.ReadLine();
            Console.Write("Model: ");
            s.Model = Console.ReadLine();
            Console.Write("Cena: ");
            s.Cena = Convert.ToDecimal(Console.ReadLine());
            samochody.Add(s);
        }

        /// <summary>
        /// Procedura usunięcia wybranego samochodu z tablicy
        /// </summary>
        public void Usun()
        {
            Console.Clear();
            Console.WriteLine("-- Nad tą opcją jeszcze pracujemy --");
            Console.WriteLine("ENTER - powrót");
            ConsoleKeyInfo info = new ConsoleKeyInfo();
            while (info.Key != ConsoleKey.Enter)
            {
                info = Console.ReadKey();
            }
        }

        /// <summary>
        /// Wyświetla samochody w tablicy
        /// </summary>
        public void Wyswietl()
        {
            if (samochody.Count() > 0)
            {
                Menu listaAut = new Menu(samochody.Count() + 1);
                foreach (Samochod s in samochody)
                {
                    listaAut.Dodaj(s.Opis());
                }
                listaAut.Dodaj("Powrót");

                while (true)
                {
                    int wybor = listaAut.Wybor();

                    if (wybor < listaAut.liczbaElementow - 1)
                    {
                        Console.WriteLine("Wybrany samochód:");
                        samochody[wybor].Wyswietl();
                    }
                    else
                    {
                        break;
                    }
                }


            }
            else
            {
                Console.Clear();
                Console.WriteLine("-- Brak samochodów --");

                Console.WriteLine("ENTER - powrót");
                ConsoleKeyInfo info = new ConsoleKeyInfo();
                while (info.Key != ConsoleKey.Enter)
                {
                    info = Console.ReadKey();
                }
            }
        }

        public List<Samochod> Lista()
        {
            return samochody;
        }
    }
}
