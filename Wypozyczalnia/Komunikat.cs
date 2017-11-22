using System;
using System.Collections.Generic;
using System.Text;

namespace Wypozyczalnia
{
    /*
        TODO - zastosować gdzie się da 
    */

    class Komunikat
    {
        string napis;

        public Komunikat(string napis)
        {
            this.napis = napis;
        }

        /// <summary>
        /// Wyświetla komunikat z zapytaniem w formule tak/nie
        /// </summary>
        /// <param name="tak">Opis odpowiedzi "tak"</param>
        /// <param name="nie">Opis odpowiedzi "nie"</param>
        /// <returns></returns>
        public bool Zapytaj(string tak, string nie)
        {
            Console.Clear();
            Console.WriteLine(napis);

            Console.WriteLine("ENTER - " + tak + " ESC - " + nie);
            ConsoleKeyInfo info = new ConsoleKeyInfo();
            while ((info.Key != ConsoleKey.Enter) && (info.Key != ConsoleKey.Escape))
            {
                info = Console.ReadKey();
            }
            if (info.Key == ConsoleKey.Enter)
                return true;
            return false;
        }

        /// <summary>
        /// Wyświetla prosty komunikat, który można tylko zatwierdzić
        /// </summary>
        public void Wyswietl()
        {
            Console.Clear();
            Console.WriteLine(napis);

            Console.WriteLine("ENTER - ok");
            ConsoleKeyInfo info = new ConsoleKeyInfo();
            while (info.Key != ConsoleKey.Enter)
            {
                info = Console.ReadKey();
            }
        }
    }
}
