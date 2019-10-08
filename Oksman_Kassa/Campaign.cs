using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oksman_Kassa
{
    public class Campaign
    {
        public int ProductID;
        public DateTime Date1;
        public DateTime Date2;
        public double CampaignPrice;

        public Campaign(int productID, DateTime date1, DateTime date2, double campaignPrice)
        {
            this.ProductID = productID;
            this.Date1 = date1;
            this.Date2 = date2;
            this.CampaignPrice = campaignPrice;
        }

        public static double CampaignRead(int TempProductID,double originalPris)
        {

            double FinalPrice = 0;
            DateTime date1;
            DateTime date2;
            var Campaigns = new List<Campaign>();

            if (System.IO.File.Exists(@"../../campaign.txt"))
            {
                using (System.IO.StreamReader Filen = System.IO.File.OpenText(@"../../campaign.txt"))
                {
                    string Rad;


                    while ((Rad = Filen.ReadLine()) != null)
                    {
                        String[] ProductInfo = Rad.Split(',');
                        int productID = int.Parse(ProductInfo[0]);


                        DateTime.TryParse(ProductInfo[1], out date1);
                        DateTime.TryParse(ProductInfo[2], out date2);
                        double.TryParse(ProductInfo[3], out double CampaignPrice);

                        var Item = new Campaign(productID, date1, date2, CampaignPrice);
                        Campaigns.Add(Item);

                    }

                    foreach (Campaign C in Campaigns)
                    {
                        if(TempProductID == C.ProductID)
                        {
                            if (C.Date1 < DateTime.Now && DateTime.Now < C.Date2)
                            {
                                FinalPrice = C.CampaignPrice;
                                return FinalPrice;
                            }
                        }

                    }
                    
                }
            }
            if(FinalPrice == 0) { return originalPris; }
            else
            return FinalPrice;

        }
        public static void CampaignDateChange()
        {
            while (true)
            {
                Console.Clear();
                Menu.PrintProducts();
                Console.WriteLine("Ändra Datum: Ange det produkt ID du vill ändra.");
                bool isFound = false;
                DateTime Date1;
                DateTime Date2;
                int IdInput = Menu.ReturnMenuInput();
                int SelectedID=0;
                var Products = Produkt.GetProducts();

                foreach(Produkt P in Products)
                {
                    if(P.ProductID == IdInput)
                    {

                        SelectedID = IdInput;
                        isFound = true;
                    }


                }
                if (!isFound) { Console.WriteLine("Hittade inte produkten. Försök igen.."); continue; }


                while(true)
                { 
                    Console.Clear();

                    Console.WriteLine("Ange Start Datum - Format YYYY,MM,DD");
                    Date1 = Menu.ReturnDateTime();

                    Console.WriteLine("Ange Slut Datum - Format YYYY,MM,DD");
                    Date2 = Menu.ReturnDateTime();

                    if(Date2 < Date1) { Console.WriteLine("Slut Datum kan inte vara innan Start Datum! Försök igen!"); Console.ReadLine(); continue; }
                    break;
                }

                var Campaigns = ReturnCampaignFile();

                foreach (Campaign C in Campaigns)
                {

                    if (C.ProductID == SelectedID)
                    {
                        C.Date1 = Date1;
                        C.Date2 = Date2;

                        if(C.CampaignPrice > 0)
                        Console.WriteLine($"Produkt ID: {C.ProductID} har nu kampanj från {Date1.ToString("yyyy/MM/dd")} till {Date2.ToString("yyyy/MM/dd")} för {C.CampaignPrice}kr");
                        else
                        Console.WriteLine($"Produkt ID: {C.ProductID} har nu kampanj från {Date1.ToString("yyyy/MM/dd")} till {Date2.ToString("yyyy/MM/dd")}");

                    }

                }
                Console.ReadLine();
                CampaignWrite(Campaigns);
                break;




            }
        }


        public static void CampaignPriceChange()
        {
            while (true)
            {
                Console.Clear();
                Menu.PrintProducts();
                Console.WriteLine("Ändra Pris: Ange det produkt ID du vill ändra.");
                bool isFound = false;
                int IdInput = Menu.ReturnMenuInput();
                int SelectedID = 0;
                var Products = Produkt.GetProducts();

                foreach (Produkt P in Products)
                {
                    if (P.ProductID == IdInput)
                    {

                        SelectedID = IdInput;
                        isFound = true;
                    }


                }
                if (!isFound) { Console.WriteLine("Hittade inte produkten. Försök igen.."); continue; }

                Console.Clear();
                Console.Write("Ange Kampanj Pris: ");
                Double Price = Menu.ReturnPrice();

                var Campaigns = ReturnCampaignFile();

                foreach (Campaign C in Campaigns)
                {

                    if (C.ProductID == SelectedID)
                    {
                        C.CampaignPrice = Price;
                        if (C.CampaignPrice > 0)
                            Console.WriteLine($"Produkt ID: {C.ProductID} har nu kampanj från {C.Date1.ToString("yyyy/MM/dd")} till {C.Date2.ToString("yyyy/MM/dd")} för {Price}kr");
                        else
                            Console.ReadLine();

                    }

                }

                Console.ReadLine();
                CampaignWrite(Campaigns);
                break;

            }


        }

        public static void CampaignRemove()
        {
            while(true)
            {

                Console.Clear();
                Menu.PrintProducts();
                Console.WriteLine("Ta Bort Kampanj: Ange det produkt ID du vill ändra.");
                int IdInput = Menu.ReturnMenuInput();
                var Campaigns = ReturnCampaignFile();

                foreach (Campaign C in Campaigns)
                {

                    if (C.ProductID == IdInput)
                    {
                        C.Date1 = new DateTime (0001, 01, 01);
                        C.Date2 = new DateTime (0001, 01, 01);
                        Console.WriteLine($"Produkt ID: {C.ProductID} har nu ingen kampanj.");

                    }

                }
                Console.ReadLine();
                CampaignWrite(Campaigns);
                break;
            }

        }

        public static List<Campaign> ReturnCampaignFile()
        {
            var Campaigns = new List<Campaign>();
            if (System.IO.File.Exists(@"../../campaign.txt"))
            {
                using (System.IO.StreamReader Filen = System.IO.File.OpenText(@"../../campaign.txt"))
                {
                    string Rad;
                    DateTime date1;
                    DateTime date2;


                    while ((Rad = Filen.ReadLine()) != null)
                    {
                        String[] ProductInfo = Rad.Split(',');
                        int productID = int.Parse(ProductInfo[0]);
                        DateTime.TryParse(ProductInfo[1], out date1);
                        DateTime.TryParse(ProductInfo[2], out date2);
                        double.TryParse(ProductInfo[3], out double CampaignPrice);

                        var Item = new Campaign(productID, date1, date2, CampaignPrice);
                        Campaigns.Add(Item);

                    }

                    return Campaigns;
                }
            }
            else
            {
                Console.WriteLine("Could not find file."); return Campaigns;
            }

        }

        public static void CampaignWrite(List<Campaign>Campaigns)
        {

            String CampaignPath = @"../../Campaign.txt";
            Console.Clear();

            using (var Filen = System.IO.File.CreateText(CampaignPath))
            {

                foreach (Campaign C in Campaigns)
                {

                    Filen.WriteLine(C.ProductID + "," + C.Date1.ToString("yyyy/MM/dd") + "," + C.Date2.ToString("yyyy/MM/dd") + "," + C.CampaignPrice);

                }


            }
               
 
        }

    }
}
