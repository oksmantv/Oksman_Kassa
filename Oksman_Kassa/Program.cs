using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Ett kassasystem är ju ett sånt som kassapersonalen använder i en butik för att registrera försäljning
och skapa ett kvitto.

Alla produkter lagras i en textfil. När programmet startas läses en textfil in med data och alla objekt
skapas. Tips! Läs på mer om ToString och Parse som kan ta fler parametrar som styr hur tal och
datum formateras och tolkas. Kolla in InvariantCulture som är en variant av CultureInfo som ofta
används för import och export.

 Följande data ska lagras på Produkt,
produktid (snabbkommando i kassan, ex ”300” för bananer nedan)
pris
pris typ – är det per kilo eller per styck
produktnamn

När man kör kassan ska det se ut ungefär som följer:

Vid val av 1 startas då en ny försäljning
Systemet ska då visa aktuellt kvitto (de produkter som registrerats) samt en kommandoinmatning. 

Krav för Godkänt
Kommandoinmatningen är antingen
PAY (då ”fejkar” vi att betalning sker) och kvittot sparas i en fil (se nedan) och programmet får
tillbaka till menyn innan
produktid antal (ex ex 300 1, betyder lägg till en av produktid ”300”)
Kvitton sparas ned vid PAY till en fil RECEIPT_yyyyMMdd.txt (dagens datum). OBS! Det blir alltså
FLERA kvitton i samma fil. Fundera ut och implementera ngn slags särskiljare så man kan skilja olika
kvitton åt
Objektorienterad kod!
Console-applikation
Felhantering: korrekta inmatningar osv osv
// TEST
*/


namespace Oksman_Kassa
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Kassa_Active = true;
            while(Kassa_Active)
            {
                int UserInput = Menu.OpenStartMenu();
                switch (UserInput)
                {
                    case 1: { NyKund.Kassa(); break; }
                    case 2: { Kassa_Active = false; return; }
                    case 3:
                        {
                            Console.WriteLine("Input Date: 2019,10,02");
                            string DateInput = Console.ReadLine();
                            string[] dates = DateInput.Split(',');
                            int[] TrueDate = Array.ConvertAll<string, int>(dates, int.Parse);

                            DateTime Datum = new DateTime(TrueDate[0], TrueDate[1], TrueDate[2]);
                            Kvitto.ReadKvitto(Datum);
                            Console.WriteLine("Tryck Enter för att gå tillbaka..");
                            Console.ReadLine();
                            Console.Clear(); break;
                        }

                }

            }
        }
    }
}
