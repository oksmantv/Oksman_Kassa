using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Oksman_Kassa
{
    class Menu
    {
        public static int OpenStartMenu()
        {
            Console.Clear();
            Console.WriteLine("KASSA");
            Console.WriteLine("1. Ny Kund");
            Console.WriteLine("2. Avsluta");
            Console.WriteLine("3. Admin");

            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput)) { Console.WriteLine("Ange endast siffror i din inmatning"); }

            return userInput;

        }

        public static void OpenAdminMenu()
        {

            while(true)
            {
                Console.Clear();
                Console.WriteLine("ADMIN");
                Console.WriteLine("1. Ändra Produkt Namn");
                Console.WriteLine("2. Ändra Produkt Pris");
                Console.WriteLine("3. Begränsa Produkt Antal");
                Console.WriteLine("4. Ändra Kampanj");
                Console.WriteLine("5. Läs Kvitto");
                Console.WriteLine("6. Återvänd");

                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput)) { Console.WriteLine("Ange endast siffror i din inmatning"); }


                switch (userInput)
                {
                    case 1: { Produkt.ChangeName(); continue; }
                    case 2: { Produkt.ChangePrice(); continue; }
                    case 3: { Produkt.ChangeMax(); continue; }
                    case 4: { Menu.OpenCampaignMenu(); continue; }
                    case 5: { Menu.OpenSearchMenu(); break; }
                    case 6: { return; }
                    default: { Console.WriteLine("Fel inmatning. Följ Menyns gränser."); continue; }

                }
            }
        }

        public static void OpenCampaignMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CAMPAIGN");
                Console.WriteLine("1. Ändra Kampanj Datum");
                Console.WriteLine("2. Ändra Kampanj Pris");
                Console.WriteLine("3. Ta bort Kampanj");
                Console.WriteLine("4. Återvänd");

                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput)) { Console.WriteLine("Ange endast siffror i din inmatning"); }

                switch (userInput)
                {
                    case 1: { Campaign.CampaignDateChange(); break; }
                    case 2: { Campaign.CampaignPriceChange(); break; }
                    case 3: { Campaign.CampaignRemove(); break; }
                    case 4: { return; }
                    default: { Console.WriteLine("Fel inmatning. Följ Menyns gränser."); break; }


                }
            }

        }

        public static void OpenSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("Input Date: YYYY,MM,DDD\nAnge EXIT för att återvända");

            while (true)
            {
                string DateInput = Console.ReadLine();
                if (DateInput.ToUpper() == "EXIT") break;

                if (DateTime.TryParse(DateInput, out DateTime Datum))
                {

                    Kvitto.ReadKvittoShort(Datum);
                    Kvitto.ReadKvitto(Datum);
                    Console.WriteLine("Tryck Enter för att gå tillbaka..");
                    Console.ReadLine();
                    Console.Clear(); break;

                }
                else
                {
                    Console.WriteLine("Fel typ av inmatning. Följ Formatet!");
                }

            }


        }

        public static int ReturnMenuInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input)) { Console.WriteLine("Fel form av inmatning. Endast siffror!"); }
            return input;

        }

        public static DateTime ReturnDateTime()
        {
            DateTime Datum1;
            while (!DateTime.TryParse(Console.ReadLine(), out Datum1))
            {
                Console.WriteLine("Fel angivet format - YYYY,MM,DD");
            }
            Console.Clear();
            return Datum1;
        }

        public static double ReturnPrice()
        {
            while(true)
            { 
                double price;
                while(!double.TryParse(Console.ReadLine(),out price)) { Console.WriteLine("Fel inmatning. Ange endast siffror."); }
                if (price > 0)
                    return price;
                else
                    Console.WriteLine("Fel inmatning. Måste vara över 0.");
            }
        }
    }
}
