using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wypozyczalnia
{
    class Flota
    {
        List<Samochod> samochody;
        XmlDocument document;

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
            Komunikat k = new Komunikat("Dodano");
            k.Powiadom();
        }

        /// <summary>
        /// Procedura usunięcia wybranego samochodu z tablicy
        /// </summary>
        public void Usun()
        {
            // Można przebudować sensowniej
            if(samochody.Count() > 0)
            {
                while (true)
                {
                    // Jeżeli użytkownik usunął wszystkie samochody, to powrót do głównego menu !!!
                    if (samochody.Count() == 0)
                        break;

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
                            k.Powiadom();
                        }
                        else
                        {
                            k = new Komunikat("Anulowano");
                            k.Powiadom();
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
                k.Powiadom();
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
                k.Powiadom();
            }
        }

        // TODO:
        public void Wczytaj()
        {

        }

        // TODO:
        public void Zapisz()
        {
            document = new XmlDocument();

            // Rzuca wyjątek:
            //document.Load("Flota.xml");

        }
    }
}
