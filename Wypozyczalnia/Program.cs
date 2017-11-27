using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menuGlowne = new Menu(5);
            menuGlowne.Dodaj("Dodaj samochód");
            menuGlowne.Dodaj("Usuń samochód");
            menuGlowne.Dodaj("Pokaż flotę");
            menuGlowne.Dodaj("Wyjdź");

            Flota flota = new Flota(100);

            flota.Wczytaj();

            int wybor = 0;
            while (wybor != 2)
            {
                switch (menuGlowne.Wybor())
                {
                    case 0:
                        flota.Dodaj();
                        break;
                    case 1:
                        flota.Usun();
                        break;
                    case 2:
                        flota.Wyswietl();
                        break;
                    case 3:
                        flota.Zapisz();
                        return;
                }
            }
        }
    }
}
