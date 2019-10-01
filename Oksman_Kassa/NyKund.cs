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

            Console.WriteLine("KASSA");
            Console.WriteLine("KVITTO\r\r{0}", KvittoTime);

            Console.WriteLine("Total: {1}");
            Console.WriteLine("kommandon:\n<productid> <antal>\nPAY");
            Console.Write("Kommando:");


            string UserInput = Console.ReadLine();
            String[] KommandoInfo = UserInput.Split(' ');

            int ProductID = int.Parse(KommandoInfo[0]);
            int ProductAmount = int.Parse(KommandoInfo[1]);

                foreach (Produkt P in ProductList)
                {

                    if (ProductID == P.ProductID)
                    { 
                        var Item = new KassaItem(P.Namn, P.Pris, P.Typ, ProductAmount);
                        ItemList.Add(Item);

                    }       

                }

            switch (UserInput)
            {

            }

        }


    }
}
