using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    struct Samochod
    {
        /// <summary>
        /// Nieujemna wartość całkowitoliczbowa
        /// </summary>
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value >= 0)
                    id = value;
            }
        }

        /// <summary>
        /// Wartość typu decimal większa lub równa zeru i mniejsza lub równa 1000
        /// </summary>
        private decimal cena;
        public decimal Cena
        {
            get
            {
                return cena;
            }
            set
            {
                if (value >= 0 && value <= 1000)
                    cena = value;
            }
        }

        private string marka;
        public string Marka { get => marka; set => marka = value; }

        private string model;
        public string Model { get => model; set => model = value; }
       
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
