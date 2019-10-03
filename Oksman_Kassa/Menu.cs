using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TEST

namespace Oksman_Kassa
{
    class Menu
    {
        public static int OpenStartMenu()
        {
            Console.WriteLine("KASSA");
            Console.WriteLine("1. Ny Kund");
            Console.WriteLine("2. Avsluta");
            Console.WriteLine("3. Läs Kvitto");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput)) { Console.WriteLine("Ange endast siffror i din inmatning"); }

            return userInput;

        }



    }
}
