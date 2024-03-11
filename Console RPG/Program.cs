using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine("Please input a name");
            String playerName = Console.ReadLine();
            Player mainPlayer = new Player(playerName, 10, 1, new Stats(2, 2, 2, 2));
            Console.ForegroundColor= ConsoleColor.White;
            

            
            Player.inventory.Add(DamageItems.thermonucularBomb);
            
            
            
            
            Location.PlayerHouse.SetNearbyLocation(Location.BurgerKing, Location.PerrysHouse, Location.PizzaHut, Location.TheVoid);
            Location.BurgerKing.SetNearbyLocation(Location.mcDonalds, Location.oliveGarden);
            Location.mcDonalds.SetNearbyLocation(Location.SnoIsle,null,Location.BurgerKing,null);
            Location.SnoIsle.SetNearbyLocation(Location.thomasHouse,Location.graveyard,Location.mcDonalds,Location.Costco);
            Location.PerrysHouse.SetNearbyLocation(Location.oliveGarden,Location.MathewsHouse);
            Location.kalebsHouse.SetNearbyLocation(Location.billGaytes,west: Location.oliveGarden);
            Location.MathewsHouse.SetNearbyLocation(Location.kalebsHouse, south: Location.gameStop);
            Location.forest.SetNearbyLocation(north: Location.PizzaHut, west: Location.cave);
            Location.cave.SetNearbyLocation(west: Location.deepCave);
            
            Console.ForegroundColor = ConsoleColor.White;
            Location.PlayerHouse.Resolve(new List<Player>() { mainPlayer });
            
        }
    }
}
