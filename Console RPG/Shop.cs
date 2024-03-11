using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;

namespace Console_RPG
{
    class Shop : Events
    {
        
        public List<Items> purchases;
        public string shopName;
        public string shopKeeperName;

        public Shop(string shopName, string shopKeeperName, List<Items> purchases) : base(false)
        {
            this.shopName = shopName;
            this.shopKeeperName = shopKeeperName;
            this.purchases = purchases;
        }

        public override void Resolve(List<Player> players)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("Buy | Sell | Sell all | Leave");
                Console.WriteLine($"{Player.money} coins.");
                string userChoice = Console.ReadLine().ToLower();
                if (userChoice == "buy")
                {
                    Items item = ChooseBuyItem(purchases, players);
                    if (item.sellPrice <= Player.money)
                    {
                        Player.money -= item.shopPrice;
                        Player.inventory.Add(item);
                        Console.WriteLine($"You have bought a {item.name} !");
                    }
                    else
                    {
                        Console.WriteLine("YOU BROKE, GET OUTA HERE!");
                    }
                }
                else if (userChoice == "sell")
                {
                    Items item = ChooseSellItem(Player.inventory, players);
                    
                        Player.money += item.sellPrice;
                        Player.inventory.Remove(item);
                        Console.WriteLine($"You have sold a {item.name} !");  
                }
                else if (userChoice == "sell all")
                {
                    SellAll(Player.inventory, players);          
                }
                else if (userChoice == "leave")
                {
                    break;
                }
            }
        }

        public Items ChooseBuyItem(List<Items> items, List<Player> players)
        {
            Console.WriteLine("Choose whomst to buy (Or say exit to exit).");
            int playerChoise = 0;
            while (playerChoise >= 0 && playerChoise <= items.Count)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + items[i].name + ", " + items[i].shopPrice + " coins to buy. " + items[i].description );
                }
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    Player.location.Resolve(players);
                }
                else if (int.TryParse(input, out int v))
                {
                    playerChoise = Convert.ToInt32(input);
                }

                
            }
            return items[playerChoise - 1];
        }
        public Items ChooseSellItem(List<Items> items, List<Player> players)
        {
            Console.WriteLine("Choose whomst to sell (Or say exit to exit).");
            int playerChoise = 0;
            while (playerChoise >= 0 && playerChoise <= items.Count)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + items[i].name + ", " + items[i].sellPrice + " coins to sell. " + items[i].description);
                }
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    Player.location.Resolve(players);
                }
                else if (int.TryParse(input, out int v))
                {
                    playerChoise = Convert.ToInt32(input);
                }
                
            }
            return items[playerChoise - 1];
        }
        public void SellAll(List<Items> items, List<Player> players)
        {
           int m = 0;
                for (int i = 0; i < items.Count; i++)
                {
                Player.money += items[i].sellPrice;
                m += items[i].sellPrice;
                Player.inventory.Remove(items[i]);
                }
            Console.WriteLine($"You sold everything and earned {m} money.");
            Console.Beep(32000, 100);
        }
    }
}
