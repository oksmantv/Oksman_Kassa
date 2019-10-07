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
            DateTime date1 = new DateTime(1999, 01, 01);
            DateTime date2 = new DateTime(1999, 01, 01);
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
        public static void CampaignWrite()
        {

            String CampaignPath = @"../../Campaign.txt";


            Console.Clear();
            if (System.IO.File.Exists(CampaignPath))
            {


                if (System.IO.File.Exists(CampaignPath))
                {

                    using (var Filen = System.IO.File.AppendText(CampaignPath))
                    {



                            Filen.WriteLine(DateTime.Now);


                    }

                }
                else
                {

                    using (var Filen = System.IO.File.CreateText(CampaignPath))
                    {

                            Filen.WriteLine(DateTime.Now);


                    }
                }
            }
 
        }

    }
}
