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
            int Index;

            String DatumFormat = Time.ToString("yyyMMdd");
            String TimeFormat = Time.ToString("hhmmss");
            String ReceiptPath = @"../../RECEIPT_" + DatumFormat + ".txt";

            if (System.IO.File.Exists(ReceiptPath))
            {
                string Text = System.IO.File.ReadAllText(ReceiptPath);
                string [] TextList = Text.Split('#');
                if (TextList == null) { Index = 1; }
                else { Index = TextList.Length; }

                using (var Filen = System.IO.File.AppendText(ReceiptPath))
                {
                    Filen.Write(Index+",");

                        foreach (KassaItem K in Listan)
                        {
                            Filen.Write(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total);

                        }
                    Filen.WriteLine("#");

                }

            }
            else
            {
                
                using (var Filen = System.IO.File.CreateText(ReceiptPath))
                {
                    Filen.Write(1 + ",");

                    foreach (KassaItem K in Listan)
                    {
                        Filen.Write(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total);

                    }
                    Filen.WriteLine("#");

                }
            }
        }


    }
}
