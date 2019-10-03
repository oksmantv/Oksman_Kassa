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
        
    }
}
