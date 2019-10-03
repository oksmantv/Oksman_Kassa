using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TEST

namespace Oksman_Kassa
{
    public class Produkt
    {
        public int ProductID;
        public double Pris;
        public string Typ;
        public string Namn;

        public Produkt(int productID, double pris, string typ, string namn)
        {
            this.ProductID = productID;
            this.Pris = pris;
            this.Typ = typ;
            this.Namn = namn;
        }

         public static List<Produkt> GetProducts()
    {
            var ProductList = new List<Produkt>();

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

            return ProductList;

    }
        
    }

   

}
