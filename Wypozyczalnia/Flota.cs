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
            if(samochody.Count() > 0)
            {
                while (true)
                {
                    Menu listaAut = new Menu(samochody.Count() + 1);
                    foreach (Samochod s in samochody)
                    {
                        listaAut.Dodaj(s.Opis());
                    }
                    listaAut.Dodaj("Powrót");

                    int wybor = listaAut.Wybor();

                    if (wybor < listaAut.liczbaElementow - 1)
                    {
                        Komunikat k = new Komunikat("Czy na pewno chcesz usunąć wybrane auto z floty?");
                        if (k.Zapytaj("Usuń", "Anuluj"))
                        {
                            samochody.RemoveAt(wybor);
                            k = new Komunikat("Usunięto");
                            k.Wyswietl();
                        }
                        else
                        {
                            k = new Komunikat("Anulowano");
                            k.Wyswietl();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                Komunikat k = new Komunikat("-- Brak samochodów --");
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
                Komunikat k = new Komunikat("-- Brak samochodów --");
                k.Wyswietl();
            }
        }

    }
}
