using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Oksman_Kassa
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Kassa_Active = true;
            while(Kassa_Active)
            {
                Console.Clear();
                int UserInput = Menu.OpenStartMenu();
                switch (UserInput)
                {
                    case 1: { NyKund.Kassa(); break; }
                    case 2: { Kassa_Active = false; return; }
                    case 3: 
                    { 
                        Console.Clear();
                        int AdminInput = Menu.OpenAdminMenu();

                            switch (AdminInput)
                            {
                                case 1: { Produkt.ChangeName(); continue; }
                                case 2: { Produkt.ChangePrice(); continue; }
                                case 3: { Produkt.ChangeMax(); continue;}
                                case 4: { Campaign.CampaignWrite(); continue;}
                                case 5:
                                    {
                                        Console.WriteLine("Input Date: YYYY,MM,DD");

                                        while (true)
                                        {
                                            string DateInput = Console.ReadLine();

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

                                        break;
                                    }
                                case 6: { break; }

                            }
                            break;
                    }  

                }

            }
        }
    }
}
