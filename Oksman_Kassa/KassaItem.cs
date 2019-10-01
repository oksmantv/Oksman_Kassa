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

        public KassaItem(string namn, double pris, string typ, double amount)
        {
            this.Amount = amount;
            this.Pris = pris;
            this.Typ = typ;
            this.Namn = namn;
        }

    }
}
