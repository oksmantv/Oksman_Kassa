using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TEST

namespace Oksman_Kassa
{
    class NyKund
    {

        public static void Kassa ()
        {

            var ItemList = new List<KassaItem>();
            

            DateTime KvittoTime = DateTime.Now;
            var ProductList = Produkt.GetProducts();


            int Number = 1000;
            double TotalSumma;
            double Rabatt=0;
            double TotalRabatt=0;
            int ProductID;
            int ProductAmount;
            bool isNotAdded;

            while (true)
            {      
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("KASSA");
                    Console.WriteLine("KVITTO    {0}", KvittoTime);
                    TotalSumma = 0;
                    isNotAdded = true;

                    if (ItemList.Count > 0)
                    {
                        
                        foreach (KassaItem K in ItemList)
                        {
                            Console.WriteLine("{0} {1}{2} * {3} = {4}", K.Namn, K.Amount,K.Typ, K.Pris.ToString("0.00"), K.Total.ToString("0.00")); 
                            TotalSumma += K.Total;
                        }

                            Console.WriteLine("Items Total: {0}", TotalSumma.ToString("0.00"));

                           if (TotalSumma > 1000 && TotalSumma < 2000)
                            {
                                Rabatt = (TotalSumma * 0.01) * -1;
                                TotalRabatt = TotalSumma * 0.99;
                                Console.WriteLine("Rabatt: {0}", Rabatt.ToString("0.00"));
                                Console.WriteLine("Total: {0}", TotalRabatt.ToString("0.00"));
                              
                            }

                            else if (TotalSumma > 2000)
                            {
                                Rabatt = (TotalSumma * 0.02) * -1;
                                TotalRabatt = TotalSumma * 0.98;
                                Console.WriteLine("Rabatt: {0}", Rabatt.ToString("0.00"));
                                Console.WriteLine("Total: {0}", TotalRabatt.ToString("0.00"));
                            }

                    }
                    
 
                
                    Console.WriteLine("\nKommandon:\n<ProductID> <Antal>\nRETURN <ProductID>\nPAY - Confirm the Order\nEXIT - Return to Main Menu");
                    Console.Write("Kommando:");
                
                    string UserInput = Console.ReadLine().ToUpper();
                    if (UserInput == "PAY") 
                    {
                        foreach (KassaItem K in ItemList)
                        {
                            K.Rabatt = Rabatt;
                            K.TotalRabatt = TotalRabatt;
                        }
                        Kvitto.CreateKvitto(KvittoTime, ItemList); Console.Clear(); return; 
                    }

                    if (UserInput == "EXIT") 
                    {
                        Console.Clear(); return; 
                    }

                        if (UserInput.Contains(" "))
                        {
                            String[] KommandoInfo = UserInput.Split(' ');
                            if (KommandoInfo[0] == "RETURN")
                            {
                                ProductID = int.Parse(KommandoInfo[1]);
                                foreach (KassaItem P in ItemList)
                                {

                                    if (ProductID == P.ProductID && P.Amount <= 1)
                                    {
                                        ItemList.Remove(P);
                                        break;
                                    }
                                    else
                                    {
                                        P.Amount = P.Amount -1;
                                        P.Total = P.Total - P.Pris;
                                    }


                                }
                                continue;
                            }
                                try
                                {
                                    ProductID = int.Parse(KommandoInfo[0]);
                                    ProductAmount = int.Parse(KommandoInfo[1]);
                                    if (ProductAmount < 0) continue;
                                    break;
                                }
                                catch(Exception E) 
                                { Console.WriteLine (E); Console.ReadLine(); }

                        }
                }

                    foreach (KassaItem T in ItemList)
                    {
                   
                        if (T.ProductID == ProductID && T.Amount > 0)
                        {
                            T.Amount += ProductAmount;
                            T.Total = T.Amount * T.Pris;
                            isNotAdded=false;
                        }

                    }

                    foreach (Produkt P in ProductList) 
                    {

                        if (ProductID == P.ProductID && isNotAdded)
                        {
                            var Item = new KassaItem(P.Namn, P.Pris, P.Typ, ProductAmount,P.ProductID,TotalRabatt,Rabatt,Number);
                            ItemList.Add(Item);

                        }

                    }
            }

        }

    }
}
