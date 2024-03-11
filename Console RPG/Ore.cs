using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Ore : Events
    {
        
        public Ore() : base(false)
        {
            
        }
        public override void Resolve(List<Player> players)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("Mine (1) | Leave (2)");
                Console.WriteLine($"{Player.money} coins.");
                string userChoice = Console.ReadLine().ToLower();
                if (userChoice == "mine" || userChoice == "1")
                {
                    Random rand = new Random();
                    int num = rand.Next(11);
                    if (num >= 9)
                    {
                        Console.WriteLine("You mined a diamond");
                        Player.inventory.Add(SellItems.diamond);
                    }
                    else if (num >= 7)
                    {
                        Console.WriteLine("You mined some gold");
                        Player.inventory.Add(SellItems.goldOre);
                    }
                    else if (num >= 6)
                    {
                        Console.WriteLine("You mined some iron");
                        Player.inventory.Add(SellItems.ironOre);
                    }
                    else if (num <= 4)
                    {
                        Console.WriteLine("You mined some coal");
                        Player.inventory.Add(SellItems.coal);
                    }
                }

                else if (userChoice == "leave" || userChoice== "2")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }
    }
}
