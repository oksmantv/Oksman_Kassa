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
            int Count;

            String DatumFormat = Time.ToString("yyyMMdd");
            String TimeFormat = Time.ToString("hhmmss");
            String ReceiptPath = @"../../RECEIPT_" + DatumFormat + ".txt";
            String CountPath = @"../../TotalCount.txt";

            if (System.IO.File.Exists(CountPath))
            {
                string Text = System.IO.File.ReadAllText(CountPath);
                string[] TextList = Text.Split(',');
                Text.Split(',').Select(Int32.Parse).ToArray();
                int MaxVal = Text.Max();
                Count = Text.ToList().IndexOf(MaxVal);
                

            }
                if (System.IO.File.Exists(ReceiptPath))
            {
                



                    using (var Filen = System.IO.File.AppendText(ReceiptPath))
                    {
                        Filen.Write("#");

                            foreach (KassaItem K in Listan)
                            {
                                Filen.Write(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total);
                            }

                    }

            }
            else
            {
                
                using (var Filen = System.IO.File.CreateText(ReceiptPath))
                {
                    Filen.WriteLine("#");
                    foreach (KassaItem K in Listan)
                    {
                        Filen.Write(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total);

                    }
                    

                }
            }
        }


    }
}
