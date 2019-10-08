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
               string path = @"../../produkter.txt";


            if (System.IO.File.Exists(path))
            {
                    
                using (var Filen = System.IO.File.CreateText(path))
                {
                    
                        foreach (Produkt P in List)
                        {
                            Filen.WriteLine(P.ProductID + "," + P.Pris + "," + P.Typ + "," + P.Namn + "," + P.MaxItems);

                        }


                }

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

        public static void PrintProductsPrice(List<Produkt> Lista)
        {
            Console.WriteLine("Current Product List");
            foreach (Produkt P in Lista)
            {
                Console.WriteLine($"Produkt ID: {P.ProductID} - Pris: {P.Pris}");

            }
            Console.WriteLine();
        }

        public static void PrintProductsName(List<Produkt> Lista)
        {
            Console.WriteLine("Current Product List");
            foreach (Produkt P in Lista)
            {
                
                Console.WriteLine($"Produkt ID: {P.ProductID} - Namn: {P.Namn}");

            }
            Console.WriteLine();
        }

        public static void PrintProductsMax(List<Produkt> Lista)
        {
            Console.WriteLine("Current Product List");
            foreach (Produkt P in Lista)
            {
                
                Console.WriteLine($"Produkt ID: {P.ProductID} - Max Antal: {P.MaxItems}");

            }
            Console.WriteLine();
        }

        public static void ChangeName()
        {  

            var ProduktLista = GetProducts();
            bool ControlCheck = true;
            string NamnInput;
            int userInput = 0;

            while (ControlCheck)
            {
                Console.Clear();
                PrintProductsName(ProduktLista);
                Console.WriteLine("Ändra Namn - Ange Produkt ID\nAnge EXIT för att återvända"); 

                

                string input;
                int.TryParse(input = Console.ReadLine(),out userInput);
                if(input.ToUpper() == "EXIT") return;

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

            while(true)
            { 
                NamnInput = Console.ReadLine();

                if (!NamnInput.All(Char.IsLetter) || NamnInput == "") { Console.WriteLine("Ange ett namn endast med bokstäver."); continue; }
                Console.Clear();
                break;
            }


            foreach (Produkt P in ProduktLista)
            {
                
                    if(P.ProductID == userInput)
                    {
                        P.Namn = NamnInput;
                        break;

                    }

            }

            
            SaveProducts(ProduktLista);
            Console.WriteLine("Tryck Enter för att fortsätta..");
            Console.ReadLine();


        }

        public static void ChangePrice()
        {  

            var ProduktLista = GetProducts();
            bool ControlCheck = true;
            int userInput = 0;
            double priceInput = 0;

            while (ControlCheck)
            {
                Console.Clear();
                PrintProductsPrice(ProduktLista);
                Console.WriteLine("Ändra Pris - Ange Produkt ID\nAnge EXIT för att återvända"); 
                
               

                string input;
                int.TryParse(input = Console.ReadLine(),out userInput);
                if(input.ToUpper() == "EXIT") return;

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

            Console.WriteLine($"Ange det nya priset på produkt ID: {userInput}");
            while(!double.TryParse(Console.ReadLine(),out priceInput) || priceInput < 1) { Console.WriteLine("Ange endast siffror. Inte under 0."); }
            Console.WriteLine($"Produkt ID {userInput} har nu priset {priceInput.ToString("0.00")}");


                foreach (Produkt P in ProduktLista)
                {
                
                    if(P.ProductID == userInput)
                    {
                        P.Pris = priceInput;
                        break;

                    }

                }

            SaveProducts(ProduktLista);
            Console.WriteLine("Tryck Enter för att fortsätta..");
            Console.ReadLine();


        }


        public static void ChangeMax()
        {  

            var ProduktLista = GetProducts();
            bool ControlCheck = true;
            int userInput = 0;
            int MaxInput = 0;

            while (ControlCheck)
            {
                Console.Clear();
                PrintProductsMax(ProduktLista);
                Console.WriteLine("Ändra Max Antal - Ange Produkt ID\nAnge EXIT för att återvända"); 
                
                

                string input;
                int.TryParse(input = Console.ReadLine(),out userInput);
                if(input.ToUpper() == "EXIT") return;

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

            Console.WriteLine($"Ange det nya max antalet på produkt ID: {userInput}");
            while(!int.TryParse(Console.ReadLine(),out MaxInput) || MaxInput < 0) { Console.WriteLine("Ange endast siffror. Inte under 0."); }

            Console.Clear();
            Console.WriteLine($"Produkt ID {userInput} har nu max antalet {MaxInput}");


                foreach (Produkt P in ProduktLista)
                {
                
                    if(P.ProductID == userInput)
                    {
                        P.MaxItems = MaxInput;
                        break;

                    }

                }

            PrintProductsMax(ProduktLista);
            Console.WriteLine("Tryck Enter för att fortsätta..");
            SaveProducts(ProduktLista);
            Console.ReadLine();


        }

    }

}
