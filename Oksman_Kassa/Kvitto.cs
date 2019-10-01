using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oksman_Kassa
{
     public class Kvitto
     {
        public static void CreateKvitto (DateTime time,List<KassaItem> List)
        {
            DateTime Time = time;
            var Listan = List;

            String DatumFormat = Time.ToString("yyyMMdd");
            String TimeFormat = Time.ToString("hhmmss");
            String ReceiptPath = @"../../RECEIPT_" + DatumFormat + ".txt";

            if (System.IO.File.Exists(ReceiptPath))
            {
                using (var Filen = System.IO.File.AppendText(ReceiptPath))
                {
                    Filen.Write("#");

                        foreach (KassaItem K in Listan)
                        {
                            Filen.WriteLine(TimeFormat+","+K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total);

                        }


                }

            }
            else
            {
                System.IO.File.Create(ReceiptPath);
                using (var Filen = System.IO.File.CreateText(ReceiptPath))
                {
                    Filen.Write("#");

                    foreach (KassaItem K in Listan)
                    {
                        Filen.WriteLine(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total);

                    }


                }
            }
        }


    }
}
