using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{

    class Menu
    {
        string[] elementy;
        public int liczbaElementow;
        int zaznaczony = 0, szerokosc = 0;

        /// <summary>
        /// Konstruktor klasy Menu()
        /// </summary>
        /// <param name="liczbaElementow">liczba elementów menu</param>
        public Menu(int liczbaElementow)
        {
            elementy = new string[liczbaElementow];
        }

        /// <summary>
        /// Dodaje nowy element menu
        /// </summary>
        /// <param name="element">Element menu</param>
        public void Dodaj(string element)
        {
            if (liczbaElementow < elementy.Length)
            {
                if (element.Length > szerokosc)
                {
                    szerokosc = element.Length;
                }
                elementy[liczbaElementow++] = element;
            }
        }

        /// <summary>
        /// Wypisuje menu w konsoli i zaznacza własciwy element
        /// </summary>
        private void Rysuj(string tytul)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(tytul.PadRight(szerokosc));
            Console.ResetColor();
            for (int i = 0; i < liczbaElementow; i++)
            {
                if (i == zaznaczony)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(elementy[i].PadRight(szerokosc));
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Zwraca indeks wybranego elementu menu
        /// </summary>
        /// <returns></returns>
        public int Wybor(string tytul)
        {
            while (true)
            {
                Rysuj(tytul);

                ConsoleKeyInfo klawisz = Console.ReadKey();
                switch (klawisz.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (zaznaczony > 0)
                        {
                            zaznaczony--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (zaznaczony < liczbaElementow - 1)
                        {
                            zaznaczony++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return zaznaczony;
                }
            }
        }
    }
}
