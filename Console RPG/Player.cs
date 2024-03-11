using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Console_RPG
{
    class Player : Entity
    {
        public static int money;
        public static int actions;
        public static Location location;
        public static List<Items> inventory = new List<Items>();

        public Armor headgear, chestpiece, legwear;
        public Weapon weapon;


        public Player(string name, int hp, int mana, Stats stats) : base(name, hp, mana, stats) 
        {
            
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.WriteLine("Choose whomst to target.");

            int playerChoise = 0;
            while (playerChoise >= 0 && playerChoise <= choices.Count -1) 
            {
                for (int i = 0; i < choices.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + choices[i].name);
                }
                string input = Console.ReadLine();
                if (int.TryParse(input, out int v))
                {
                    playerChoise = Convert.ToInt32(input);
                }

                
            }
            return choices[playerChoise - 1];
        }
        public Items ChooseItem(List<Items> items)
        {
            Console.WriteLine("Choose whomst to use.");
            int playerChoise = 0;
            while (playerChoise >= 0 && playerChoise < items.Count)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + items[i].name + ". " + items[i].description);
                }

                string input = Console.ReadLine();
                if (int.TryParse(input, out int v)) 
                {
                    playerChoise = Convert.ToInt32(input);
                }
                
            }
            return items[playerChoise - 1];
        }

        public override void Attack(Entity target)
        {
            if (this.stats.attack - target.stats.defence > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(this.name + " attacked " + target.name + " and dealt " + (this.stats.attack - target.stats.defence) + " damage!");
                target.currentHp -= (this.stats.attack - target.stats.defence);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(this.name + " attacked " + target.name + " and dealt no damage! like a weakling");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            
            
            Console.WriteLine("What do you do?\nAttack? (1)\nFlee? (2)\nCry? (3)\nItem? (4)");
            string action = Console.ReadLine().ToLower();
            int timer = 0;

            while ((action != "attack" && action != "1" ) && (action != "flee" && action != "2") && (action != "cry" && action != "3") && (action != "item" && action != "4") && timer < 5)
            {
                Console.WriteLine(action);
                Console.WriteLine("INCORRECT ACTION!\nWhat do you do?\nAttack?\nFlee?\nCry?");
                action = Console.ReadLine().ToLower();
                timer++;
            }
            if (action == "attack" || action == "1")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
                
            }
            else if (action == "flee" || action == "2")
            {
                Player.location.Resolve(players);
            }
            else if(action == "cry" || action == "3")
            {
                Console.WriteLine("You weep, nothing happens");
            }
            else if (timer >= 5) 
            {
                Console.WriteLine("Your turn gets skipped");
            }
            else if ((action == "item" || action == "4") && Player.inventory.Count > 0)
            {
                Items usage = ChooseItem(Player.inventory);
                if (usage is Equipment || usage is HealthPotionItem)
                {
                    Entity target = ChooseTarget(players.Cast<Entity>().ToList());
                    usage.Use(players[0], target);
                }
                else
                {
                    Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                    usage.Use(players[0], target);
                    inventory.Remove(usage);
                }
                
            }
            else if (action == "item" || action == "4")
            {
                Console.WriteLine("You got no items bruh, you broke af fr fr");
            }

            
        }
    }
}
