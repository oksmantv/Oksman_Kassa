using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oksman_Kassa
{
    public class Kvitto
    {
        public static void CreateKvitto(DateTime time, List<KassaItem> List)
        {
            DateTime Time = time;
            var Listan = List;
            int Count=1000;

            String DatumFormat = Time.ToString("yyyMMdd");
            String TimeFormat = Time.ToString("hhmmss");
            String ReceiptPath = @"../../RECEIPT_" + DatumFormat + ".txt";
            String CountPath = @"../../TotalCount.txt";


            Console.Clear();
            if (System.IO.File.Exists(ReceiptPath))
            {
                string Text = System.IO.File.ReadAllText(ReceiptPath);
                string[] KvittoList = Text.Split('#');

                foreach (string K in KvittoList)
                {
                    var ItemListan = new List<KassaItem>();
                    string[] ItemList = K.Split('*');
                    foreach (String S in ItemList)
                    {

                        if (S == "\r\n" || S == "") { }
                        else
                        {
                            string[] DataList = S.Split(',');
                            Count = int.Parse(DataList[8]) + 1;

                        }
                    }
                }
            }

            if (System.IO.File.Exists(ReceiptPath))
            {

                using (var Filen = System.IO.File.AppendText(ReceiptPath))
                {
                    

                    foreach (KassaItem K in Listan)
                    {
                        Filen.Write(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total + "," + K.ProductID + "," + K.TotalRabatt+","+ K.Rabatt + "," + Count + "*") ;
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
                        Filen.Write(K.Namn + "," + K.Pris + "," + K.Typ + "," + K.Amount + "," + K.Total + "," + K.ProductID + "," + K.TotalRabatt + "," + K.Rabatt + "," + 1000 +  "*");

                    }
                    Filen.Write("#");

                }
            }
        }

        public static void ReadKvitto(DateTime time)
        {
            DateTime Time = time;
            String DatumFormat = Time.ToString("yyyMMdd");
            String ReceiptPath = @"../../RECEIPT_" + DatumFormat + ".txt";

            double Rabatt = 0;
            double TotalRabatt = 0;
            int Number=0;

            string Text = System.IO.File.ReadAllText(ReceiptPath);
            string[] KvittoList = Text.Split('#');
            Console.Clear();

            // Fresh Potatoes,5,kg,5,25*Minced Meat,90,kg,2,180*
            foreach (string K in KvittoList)
            {

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
                        TotalRabatt = double.Parse(DataList[6]);
                        Rabatt = double.Parse(DataList[7]);
                        Number = int.Parse(DataList[8]);

                        var Item = new KassaItem(DataList[0], Pris, Typ, Amount, productID,TotalRabatt,Rabatt,Number);
                        ItemListan.Add(Item);
                    }

                }

                if (K == "\r\n" || K == "") { }
                    else
                    { 
                        Console.WriteLine("\nKASSA");
                        string Datum = Time.ToString("yyyy-MM-dd");
                        Console.WriteLine("KVITTO: {1}    {0}", Datum,Number);

                        if (ItemListan.Count > 0)
                        {
                            double TotalSumma = 0;
                            foreach (KassaItem C in ItemListan)
                            {
                                String Namn = C.Namn.Replace("\r\n", string.Empty);
                                Console.WriteLine("{0} {1}{2} * {3} = {4}", Namn, C.Amount,C.Typ, C.Pris.ToString("0.00"), C.Total.ToString("0.00"));
                                TotalSumma += C.Total;
                            }


                        Console.WriteLine("Items Total: {0}", TotalSumma.ToString("0.00"));

                        if (TotalSumma > 1000 && TotalSumma < 2000)
                        {
                            Rabatt = (TotalSumma / 100) * -1;
                            TotalRabatt = TotalSumma - (TotalSumma / 100);
                            Console.WriteLine("Rabatt: {0}", Rabatt.ToString("0.00"));
                            Console.WriteLine("Total: {0}", TotalRabatt.ToString("0.00"));
                        }

                        if (TotalSumma > 2000)
                        {
                            Rabatt = ((TotalSumma / 100) * 2) * -1;
                            TotalRabatt = TotalSumma - (TotalSumma / 100);
                            Console.WriteLine("Rabatt: {0}", Rabatt.ToString("0.00"));
                            Console.WriteLine("Total: {0}", TotalRabatt.ToString("0.00"));
                        }

                    }
                }
            }

            Console.ReadLine();

        }
    }
}
