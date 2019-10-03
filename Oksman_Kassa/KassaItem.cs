using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oksman_Kassa
{
    public class KassaItem
    {
        public double Amount;
        public double Pris;
        public string Typ;
        public string Namn;
        public double Total;
        public int ProductID;

        public KassaItem(string namn, double pris, string typ, double amount, int productID)
        {
            this.Amount = amount;
            this.Pris = pris;
            this.Typ = typ;
            this.Namn = namn;
            this.Total = pris * amount;
            this.ProductID = productID;
        }

    }
}
