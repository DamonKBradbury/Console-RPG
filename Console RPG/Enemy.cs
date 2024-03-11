using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        // Stats are attack, defence, magic attack, magic defense
        public static Enemy burgerKing = new Enemy("The King of Burgers", 5, 10, new Stats(3, 1, 0, 0), 1000, HealthPotionItem.burger);
        public static Enemy shortPerson1 = new Enemy("Kaleb Scott", 20, 8, new Stats(1, 1, 1, 1), 100, null);
        public static Enemy Perry = new Enemy("Perry", 5, 10, new Stats(1, 1, 1, 1), 100, null);
        public static Enemy shortPerson2 = new Enemy("Thomas", 1, 1, new Stats(1, 1, 1, 1), 20, null);
        public static Enemy god = new Enemy("Yaldabaoth", 100, 200, new Stats(10, 10, 10, 10), 10000, null);
        public static Enemy bear = new Enemy("Bear", 10, 0, new Stats(3, 3, 0, 3), 0, HealthPotionItem.meat);
        public static Enemy wolf = new Enemy("wolf", 5, 2, new Stats(2, 1, 0, 0), 0, HealthPotionItem.meat);
        public static Enemy billGates = new Enemy("Bill Gates", 20, 8, new Stats(2, 1, 0, 1), 10000, Weapon.Zanpakuto);
        public static Enemy Zombie = new Enemy("Zombie", 20, 0, new Stats(4, 4, 4, 4), 10, null);

        public Items droppedItem;
        public int moneyOnDefeat;

        public Enemy(string name, int hp, int mana, Stats stats, int moneyOnDefeat, Items droppedItem) : base(name, hp, mana, stats)
        {
            this.moneyOnDefeat = moneyOnDefeat;
            this.droppedItem = droppedItem; 
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Random random = new Random();
            return choices[random.Next(0, choices.Count)];
        }

        public override void Attack(Entity target)
        {
            Random rand = new Random();
            int num = rand.Next(2);
            if (currentMana > 0 && num == 1 && this.stats.magicAtk - target.stats.magicDef > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(this.name + " fired at " + target.name + " and dealt " + (this.stats.magicAtk - target.stats.magicDef) + " damage!");
                target.currentHp -= (this.stats.magicAtk - target.stats.magicDef);
                currentMana -= 1;
                Console.ForegroundColor= ConsoleColor.White;
            }
            else if(currentMana > 0 && num == 1) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(this.name + " fired at " + target.name + " and dealt no damage! like a weakling");
                currentMana -= 1;
                Console.ForegroundColor= ConsoleColor.White;
            }
            
            else if(this.stats.attack - target.stats.defence > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(this.name + " attacked " + target.name + " and dealt " + (this.stats.attack - target.stats.defence) + " damage!");
                target.currentHp -= (this.stats.attack - target.stats.defence);
                Console.ForegroundColor= ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(this.name + " attacked " + target.name + " and dealt no damage! like a weakling");
                Console.ForegroundColor= ConsoleColor.White;
            }
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
