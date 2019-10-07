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
        public int MaxItems;

        public Produkt(int productID, double pris, string typ, string namn, int maxItems)
        {
            this.ProductID = productID;
            this.Pris = pris;
            this.Typ = typ;
            this.Namn = namn;
            this.MaxItems = maxItems;
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
                        int MaxItems = int.Parse(ProductInfo[4]);

                        var Produkt = new Produkt(productID,Pris, ProductInfo[2], ProductInfo[3], MaxItems);
                        ProductList.Add(Produkt);

                    }
                }

                return ProductList;

        }

        public static void SaveProducts(List<Produkt> List)
        {

               using (System.IO.StreamReader Filen = System.IO.File.OpenText(@"../../produkter.txt"))
               {



               }




        }


        public static void PrintProducts(List<Produkt> Lista)
        {
            foreach (Produkt P in Lista)
            {

                Console.WriteLine($"Produkt ID: {P.ProductID}");
                Console.WriteLine($"Produkt Namn: {P.Namn}");
                Console.WriteLine($"Produkt Pris: {P.Pris}");
                Console.WriteLine($"Produkt Typ: {P.Typ}");
                Console.WriteLine($"Produkt Max: {P.MaxItems}\n");

            }
            Console.ReadLine();
        }

        public static void PrintProductsShort(List<Produkt> Lista)
        {
            foreach (Produkt P in Lista)
            {

                Console.WriteLine($"Produkt ID: {P.ProductID} - Namn: {P.Namn}");

            }
        }


        public static void SaveNewProducts()
        {  

            var ProduktLista = GetProducts();
            bool ControlCheck = true;
            int userInput = 0;

            while (ControlCheck)
            {

                Console.WriteLine("Ändra Namn - Ange Produkt ID"); 
                Console.Clear();
                PrintProductsShort(ProduktLista);

                int.TryParse(Console.ReadLine(),out userInput);
                foreach (Produkt P in ProduktLista)
                {
                
                    if(P.ProductID == userInput)
                    {
                        ControlCheck = false;
                        break;

                    }

                }
                if(!ControlCheck) break;
                Console.WriteLine("Kunde ej hitta produkt ID. Tryck Enter för att försöka igen...");
                Console.ReadLine();


            }

            Console.WriteLine($"Ange det nya namnet på produkt ID: {userInput}");
            string NamnInput = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Produkt ID {userInput} har nu namnet {NamnInput}");
            Console.ReadLine();


        }

    }

}
