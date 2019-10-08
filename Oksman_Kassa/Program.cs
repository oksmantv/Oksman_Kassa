using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Oksman_Kassa
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Kassa_Active = true;
            while(Kassa_Active)
            {
                Console.Clear();
                int UserInput = Menu.OpenStartMenu();
                switch (UserInput)
                {
                    case 1: { NyKund.Kassa(); break; }
                    case 2: { Kassa_Active = false; break; }
                    case 3: { Menu.OpenAdminMenu(); break; }
                    default: { Console.WriteLine("Fel inmatning. Följ Menyns gränser."); continue; }

                }

            }
        }
    }
}
