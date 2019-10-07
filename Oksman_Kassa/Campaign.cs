using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oksman_Kassa
{
    class Campaign
    {
        public static double CampaignWrite(int productID)
        {

            String CampaignPath = @"../../Campaign.txt";


            Console.Clear();
            if (System.IO.File.Exists(CampaignPath))
            {


                if (System.IO.File.Exists(CampaignPath))
                {

                    using (var Filen = System.IO.File.AppendText(CampaignPath))
                    {


                        foreach (KassaItem K in Listan)
                        {
                            Filen.WriteLine(DateTime.Now);
                        }

                    }

                }
                else
                {

                    using (var Filen = System.IO.File.CreateText(CampaignPath))
                    {

                        foreach (KassaItem K in Listan)
                        {
                            Filen.WriteLine(DateTime.Now);
                        }

                    }
                }
            }
        }

    }
}
