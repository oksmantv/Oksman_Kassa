using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oksman_Kassa
{
    class NyKund
    {

        public static void Kassa ()
        {
            var ProductList = new List<Produkt>();
            var ItemList = new List<KassaItem>();
            

            DateTime KvittoTime = DateTime.Now;

            using (System.IO.StreamReader Filen = System.IO.File.OpenText(@"../../produkter.txt"))
            {
                string Rad;
                while ((Rad = Filen.ReadLine()) != null)
                {
                    String[] ProductInfo = Rad.Split(',');
                    int productID = int.Parse(ProductInfo[0]);
                    double Pris = double.Parse(ProductInfo[1]);

                    var Produkt = new Produkt(productID,Pris, ProductInfo[2], ProductInfo[3]);
                    ProductList.Add(Produkt);

                }
            }

            double TotalSumma;
            int ProductID;
            int ProductAmount;
            while (true)
            {      
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("KASSA");
                    Console.WriteLine("KVITTO    {0}", KvittoTime);

                    if (ItemList.Count > 0)
                    {
                        TotalSumma = 0;
                        foreach (KassaItem K in ItemList)
                        {
                        
                            Console.WriteLine("{0} {1} * {2} = {3}", K.Namn, K.Amount, K.Pris.ToString("0.00"), K.Total.ToString("0.00"));
                        
                            TotalSumma += K.Total;
                        }
                        if (TotalSumma > 1000)
                        Console.WriteLine("Total: {0}", TotalSumma.ToString("0.00"));
                    }
                
                    Console.WriteLine("kommandon:\n<productid> <antal>\nPAY\nRETURN <productid>");
                    Console.Write("Kommando:");
                
                    string UserInput = Console.ReadLine();
                    if (UserInput == "PAY") { Kvitto.CreateKvitto(KvittoTime, ItemList); return; }

                        if (UserInput.Contains(" "))
                        {
                            String[] KommandoInfo = UserInput.Split(' ');
                            if (KommandoInfo[0] == "RETURN")
                            {
                                ProductID = int.Parse(KommandoInfo[1]);
                                foreach (KassaItem P in ItemList)
                                {

                                    if (ProductID == P.ProductID)
                                    {
                                        ItemList.Remove(P);
                                        break;
                                    }

                                }

                            }
                                try
                                {
                                    ProductID = int.Parse(KommandoInfo[0]);
                                    ProductAmount = int.Parse(KommandoInfo[1]);
                                    if (ProductAmount < 0) continue;
                                    break;
                                }
                                catch { }

                        }
                }
                    foreach (Produkt P in ProductList)
                    {

                        if (ProductID == P.ProductID)
                        {
                            var Item = new KassaItem(P.Namn, P.Pris, P.Typ, ProductAmount,P.ProductID);
                            ItemList.Add(Item);

                        }

                    }
            }

        }

    }
}
