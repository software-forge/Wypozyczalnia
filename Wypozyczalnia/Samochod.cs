using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    struct Samochod
    {
        public int id;
        public decimal Cena;
        public string Marka;
        public string Model;

        /// <summary>
        /// Wyświetla w konsoli informacje o samochodzie
        /// </summary>
        public void Wyswietl()
        {
            Console.Clear();
            Console.WriteLine("Marka: {0} Model: {1} Cena: {2}", Marka, Model, Cena);

            Console.WriteLine("ENTER - powrót");
            ConsoleKeyInfo info = new ConsoleKeyInfo();
            while (info.Key != ConsoleKey.Enter)
            {
                info = Console.ReadKey();
            }
        }

        public string Opis()
        {
            return "Marka: " + Marka + " Model: " + Model + " Cena: " + Cena;
        }
    }
}
