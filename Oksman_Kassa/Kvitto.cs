using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TEST

namespace Oksman_Kassa
{
    public class Kvitto
    {
        public static void CreateKvitto(DateTime time, List<KassaItem> List)
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
                // Find the current Max count of all receipt
                string Text = System.IO.File.ReadAllText(CountPath);
                string[] TextList = Text.Split(',');
                int[] convertedItems = Array.ConvertAll<string, int>(TextList, int.Parse);
                Count = convertedItems.Max();

            }

            if (System.IO.File.Exists(ReceiptPath))
            {

                using (var Filen = System.IO.File.AppendText(ReceiptPath))
                {
                    

                    foreach (KassaItem K in Listan)
                    {
                        Filen.Write(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total + "," + K.ProductID + "," + K.TotalRabatt + "," + K.Rabatt + "*") ;
                    }
                    Filen.Write("#");
                }

            }
            else
            {

                using (var Filen = System.IO.File.CreateText(ReceiptPath))
                {
                    
                    foreach (KassaItem K in Listan)
                    {
                        Filen.Write(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total + "," + K.ProductID + "," + K.TotalRabatt + "," + K.Rabatt + "*");

                    }
                    Filen.Write("#");

                }
            }
        }

        public static void ReadKvitto(DateTime time)
        {
            DateTime Time = time;
            double TotalSumma = 0;
            double TotalRabatt = 0;
            var KvittoListan = new List<String>();

            String DatumFormat = Time.ToString("yyyMMdd");

            String ReceiptPath = @"../../RECEIPT_" + DatumFormat + ".txt";
            String CountPath = @"../../TotalCount.txt";

            string Text = System.IO.File.ReadAllText(ReceiptPath);
            string[] KvittoList = Text.Split('#');
            Console.Clear();

            // Fresh Potatoes,5,kg,5,25*Minced Meat,90,kg,2,180*
            foreach (string K in KvittoList)
            {

                KvittoListan.Add(K);
                var ItemListan = new List<KassaItem>();

                string[] ItemList = K.Split('*');
                foreach (String S in ItemList)
                {

                    if (S == "\r\n" || S == "") { }
                    else
                    {
                        string[] DataList = S.Split(',');

                        string Namn = DataList[0];
                        double Pris = double.Parse(DataList[1]);
                        string Typ = DataList[2];
                        double Amount = double.Parse(DataList[3]);
                        int productID = int.Parse(DataList[4]);
                        double totalRabatt = double.Parse(DataList[5]);
                        double rabatt = double.Parse(DataList[6]);

                        var Item = new KassaItem(DataList[0], Pris, Typ, Amount, productID,totalRabatt,rabatt);
                        ItemListan.Add(Item);
                    }

                }

                    if (K == "\r\n" || K == "") { }
                    else
                    { 
                        Console.WriteLine("KASSA");
                        Console.WriteLine("KVITTO    {0}", Time);
                        

                        if (ItemListan.Count > 0)
                        {
                            
                            foreach (KassaItem C in ItemListan)
                            {
                                String Namn = C.Namn.Replace("\r\n", string.Empty);
                                Console.WriteLine("{0} {1} * {2} = {3}", Namn, C.Amount, C.Pris.ToString("0.00"), C.Total.ToString("0.00"));

                                TotalSumma += C.Total;
                            }


                            
                        }
                    }
            }
                            if (TotalSumma > 1000 && TotalSumma < 2000)
                            {
       
                            }

                            if (TotalSumma > 2000)
                            {

                            }

                            Console.WriteLine("Total: {0}", TotalSumma.ToString("0.00\n"));
        }
    }
}

