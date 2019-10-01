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

            DateTime KvittoTime = DateTime.Now;

            using (System.IO.StreamReader Filen = System.IO.File.OpenText(@"../../produkter.txt"))
            {
                string Rad;
                while ((Rad = Filen.ReadLine()) != null)
                {
                    String[] ProductInfo = Rad.Split(',');
                    int ProductID = int.Parse(ProductInfo[0]);
                    double Pris = double.Parse(ProductInfo[1]);

                    var Produkt = new Produkt(ProductID,Pris, ProductInfo[2], ProductInfo[3]);
                    ProductList.Add(Produkt);

                }
            }


            Console.WriteLine("KASSA");
            Console.WriteLine("KVITTO\r\r{0}", KvittoTime);
            Console.WriteLine("Total: {1}");
            Console.WriteLine("kommandon:\n<productid> <antal>\nPAY");
            Console.Write("Kommando:");


        }


    }
}
