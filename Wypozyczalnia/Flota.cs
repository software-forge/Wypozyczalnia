using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

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
            Komunikat k = new Komunikat("Dodano");
            k.Powiadom();
        }

        /// <summary>
        /// Procedura edycji atrybutów wybranego samochodu z tablicy
        /// </summary>
        public void Edytuj()
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

                    int wybor = listaAut.Wybor("EDYCJA");

                    if (wybor < listaAut.liczbaElementow - 1)
                    {
                        while(true)
                        {
                            Samochod s = samochody[wybor];
                            Menu listaAtrybutow = new Menu(5);
                            listaAtrybutow.Dodaj("ID: " + Convert.ToString(s.Id));
                            listaAtrybutow.Dodaj("Marka: " + s.Marka);
                            listaAtrybutow.Dodaj("Model: " + s.Model);
                            listaAtrybutow.Dodaj("Cena: " + Convert.ToString(s.Cena));
                            listaAtrybutow.Dodaj("Powrót");
                            int atrybut = listaAtrybutow.Wybor("EDYCJA");
                            if (atrybut == 4)
                            {
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                switch (atrybut)
                                {
                                    case 0:
                                        Console.WriteLine("ID: " + s.Id);
                                        Console.Write("Nowe ID: ");
                                        s.Id = Convert.ToInt16(Console.ReadLine());
                                        break;
                                    case 1:
                                        Console.WriteLine("Marka: " + s.Marka);
                                        Console.Write("Nowa marka: ");
                                        s.Marka = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine("Model: " + s.Model);
                                        Console.Write("Nowy model: ");
                                        s.Model = Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.WriteLine("Cena: " + s.Cena);
                                        Console.Write("Nowa cena: ");
                                        s.Cena = Convert.ToDecimal(Console.ReadLine());
                                        break;
                                }
                                samochody[wybor] = s;
                            }
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
        /// Procedura usunięcia wybranego samochodu z tablicy
        /// </summary>
        public void Usun()
        {
            // Można przebudować sensowniej
            if(samochody.Count() > 0)
            {
                while (true)
                {
                    // Jeżeli użytkownik usunął wszystkie samochody, to powrót do głównego menu
                    if (samochody.Count() == 0)
                        break;

                    Menu listaAut = new Menu(samochody.Count() + 1);
                    foreach (Samochod s in samochody)
                    {
                        listaAut.Dodaj(s.Opis());
                    }
                    listaAut.Dodaj("Powrót");

                    int wybor = listaAut.Wybor("USUWANIE");

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
                    int wybor = listaAut.Wybor("FLOTA");

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

        /// <summary>
        /// Zapełnia plik "flota.xml" samochodami z tablicy
        /// </summary>
        public void Wczytaj()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load("flota.xml");

                foreach (XmlNode carNode in document.DocumentElement.ChildNodes)
                {
                    Samochod s = new Samochod();
                    s.Marka = carNode["marka"].InnerText;
                    s.Model = carNode["model"].InnerText;
                    s.Cena = Convert.ToDecimal(carNode["cena"].InnerText);
                    samochody.Add(s);
                }
            }
            catch(System.IO.FileNotFoundException)
            {

            }
            
        }

        /// <summary>
        /// Zapisuje samochody z tablicy do pliku "flota.xml"
        /// </summary>
        public void Zapisz()
        {
            XmlDocument document = new XmlDocument();
            XmlNode fleetNode = document.CreateElement("flota");
            document.AppendChild(fleetNode);

            foreach(Samochod s in samochody)
            {
                XmlNode carNode = document.CreateElement("samochod");
                XmlAttribute id = document.CreateAttribute("id");
                id.Value = Convert.ToString(s.Id);
                carNode.Attributes.Append(id);
                fleetNode.AppendChild(carNode);

                XmlNode brandNode = document.CreateElement("marka");
                brandNode.InnerText = s.Marka;
                carNode.AppendChild(brandNode);

                XmlNode modelNode = document.CreateElement("model");
                modelNode.InnerText = s.Model;
                carNode.AppendChild(modelNode);

                XmlNode priceNode = document.CreateElement("cena");
                priceNode.InnerText = Convert.ToString(s.Cena);
                carNode.AppendChild(priceNode);
            }

            document.Save("flota.xml");
        }
    }
}
