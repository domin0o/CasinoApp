using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = 0.75;
            Guy player = new Guy() { Name = "Gracz", Cash = 100 };

            Console.WriteLine("Witaj w kasytnie. Prawdopodobieństwo przegranej: 0.75");

            while (player.Cash > 0)
            {
                player.WriteMyInfo();

                Console.Write("Stawiana kwota: ");
                string howMuch = Console.ReadLine();
                if (int.TryParse(howMuch, out int pot))
                {
                    if (pot > 0)
                    {
                        pot = player.GiveCash(pot) * 2;
                        if (random.NextDouble() > odds)
                        {
                            int winning = pot;
                            player.ReceiveCash(winning);
                            Console.WriteLine("Wygrałeś " + winning + " zł.");
                        }
                        else
                        {
                            Console.WriteLine("Niestety, przegrałeś.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Musisz postawić kwotę większą niż 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Musisz wpisać liczbę!");
                }
            }
            Console.WriteLine("Kasyno zawsze wygrywa.");
            Console.ReadLine();
        }
    }
}
