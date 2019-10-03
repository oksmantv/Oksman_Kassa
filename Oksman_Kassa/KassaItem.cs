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
        public double TotalRabatt;
        public double Rabatt;

        public KassaItem(string namn, double pris, string typ, double amount, int productID, double totalRabatt,double rabatt)
        {
            this.Amount = amount;
            this.Pris = pris;
            this.Typ = typ;
            this.Namn = namn;
            this.Total = pris * amount;
            this.ProductID = productID;
            this.TotalRabatt = totalRabatt;
            this.Rabatt = rabatt;
        }

    }
}
