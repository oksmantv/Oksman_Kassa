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
            Console.WriteLine("4. Admin");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput)) { Console.WriteLine("Ange endast siffror i din inmatning"); }

            return userInput;

        }

        public static int OpenAdminMenu()
        {
            Console.WriteLine("ADMIN");
            Console.WriteLine("1. Ändra Produkt Namn");
            Console.WriteLine("2. Ändra Produkt Pris");
            Console.WriteLine("3. Begränsa Produkt Antal");
            Console.WriteLine("4. Ändra Kampanj");
            Console.WriteLine("5. Återvänd");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput)) { Console.WriteLine("Ange endast siffror i din inmatning"); }

            return userInput;

        }


    }
}
