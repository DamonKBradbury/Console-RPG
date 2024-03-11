using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {


        public static Location PlayerHouse = new Location("Your House", "Starting place");
        public static Location BurgerKing = new Location("Burger King", "Buy some burgers", new Battle(new List<Enemy>() { Enemy.burgerKing }));
        public static Location PerrysHouse = new Location("Perry's House", "Tons of persona games", new Battle(new List<Enemy>() { Enemy.Perry }));
        public static Location MathewsHouse = new Location("Mathew's House", "Contains water guns and fire axes");
        public static Location PizzaHut = new Location("Pizza Hut", "No one out pizza's the hut", new Shop("Benicio", "Pizza Hut", new List<Items>() { HealthPotionItem.Pizza, HealthPotionItem.meat, DamageItems.throwingKnife }));
        public static Location TheVoid = new Location("The VOID", " ", new Battle(new List<Enemy>() { Enemy.god }));
        public static Location mcDonalds = new Location("McDonalds", "Clown place w/ fat people.", new Shop("Ruth", "McDonalds", new List<Items>() { HealthPotionItem.burger, HealthPotionItem.Potion1, DamageItems.thermonucularBomb }));
        public static Location SnoIsle = new Location("Sno-isle", "Do the learning", new Battle(new List<Enemy>() { Enemy.shortPerson1 }));
        public static Location thomasHouse = new Location("Thomas's House", "Switch, also a gorl :)))))) (fake info)", new Battle(new List<Enemy>() { Enemy.shortPerson2 }));
        public static Location Costco = new Location("Costco", "Buy some stuff", new Shop("Emile", "Costco", new List<Items>() { Weapon.Zanpakuto, DamageItems.grenade, HealthPotionItem.Pizza }));
        public static Location graveyard = new Location("Grave yards", "Grave and stuff", new Battle(new List<Enemy>() { Enemy.Zombie }));
        public static Location gameStop = new Location("GameStop", "Buy some games");
        public static Location kalebsHouse = new Location("Kaleb's House", "It's so tiny");
        public static Location oliveGarden = new Location("Olive Garden", "Unlimited souper salads");
        public static Location billGaytes = new Location("Bill Gates Mansion", "Money gate", new Battle(new List<Enemy>() { Enemy.billGates }));
        public static Location forest = new Location("The Forest", "Nature and stuff :thumbsUp:", new Battle(new List<Enemy>() { Enemy.wolf }));
        public static Location cave = new Location("The Cave", "Could have diamonds (minecraft reference!?!?).", new Battle(new List<Enemy>() { Enemy.bear }));
        public static Location deepCave = new Location("Deep Cave", "Lave and dungeons everywhere.", new Ore());


        public string name;
        public string description;

        public Location north, east, south, west;
        public Events feature;

        public Location(string name, string description, Events battle = null)
        {
            this.name = name;
            this.description = description;
            this.feature = battle;
        }

        public void SetNearbyLocation(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            
            if (!(north is null)) 
            {
                this.north = north;
                north.south = this;
            }

            if (!(south is null))
            {
                this.south = south;
                south.north = this;
            }

            if (!(east is null))
            {
                this.east = east;
                east.west = this;
            }

            if (!(west is null))
            {
                this.west = west;
                west.east = this;
            }
                
        }

        public void Resolve(List<Player> players)
        {
            Console.Clear();
            Console.WriteLine("You are in " + this.name);
            Console.WriteLine(this.description);
            if (feature != null)
            {
               if (feature is Battle)
                {
                    Console.WriteLine($"You see a fight in this area, say 'go' to go there");
                }
                else if (feature is Ore)
                {
                    Console.WriteLine("You see a mine in this area, say 'go' to go there");
                }
               else if (feature is Shop)
                {
                    Console.WriteLine("You see a shop in this area, say 'go' to in");
                }
            }
    

            if (!(this.north is null))
                Console.WriteLine("North: " + this.north.name);

            if (!(this.east is null))
                Console.WriteLine("East: " + this.east.name);

            if (!(this.south is null))
                Console.WriteLine("South: " + this.south.name);

            if (!(this.west is null))
                Console.WriteLine("West: " + this.west.name);


            string direction = Console.ReadLine().ToLower();
            Location nextLocation = null;

            if (direction == "go")
                feature?.Resolve(players);
            if (direction == "north" && !(this.north is null))
                nextLocation = this.north;
            else if (direction == "east" && !(this.east is null))
                nextLocation = this.east;
            else if (direction == "south" && !(this.south is null))
                nextLocation = this.south;
            else if (direction == "west" && !(this.west is null))
                nextLocation = this.west;
            else
            {
            Console.WriteLine("Invalid Location, try again");
            Resolve(players);
            }

            Player.location = nextLocation;
            nextLocation.Resolve(players);
        }
    }
}
