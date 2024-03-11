using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Console_RPG
{
    class Battle : Events
    {
        public List<Enemy> enemies;
        
        public Battle(List<Enemy> enemies) : base(false) 
        {
            this.enemies = enemies;
        }
        public override void Resolve(List<Player> players)
        {
            foreach (var enemy in enemies)
            {
                enemy.currentHp = enemy.maxHp;
            }
            //loops turns (great epee)
            while (true)
            {
                
                //loops through all the players (monkey tea smoothie)
                foreach (var player in players)
                {
                    if (player.currentHp > 0) {
                        Console.WriteLine($"It is {player.name}'s turn");
                        player.DoTurn(players, enemies);
                    }
                }

                //loops through all the enemies (fried rice at eddy's)
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHp > 0)
                    {
                        Console.WriteLine($"It is {enemy.name}'s turn");
                        enemy.DoTurn(players, enemies);
                    }
                }
                
                //player deaths (5/9ths already)
                if (players.TrueForAll(player => player.currentHp <= 0))
                {
                    Console.WriteLine("you dead fr fr.");
                    //StupidIdiot.Install(virus.exe);
                    break;
                }

                //player wins (fried rice at denny's)
                if (enemies.TrueForAll(enemy => enemy.currentHp <= 0))
                {
                    int moneyGained = 0;
                    for (int i = 0; i < enemies.Count(); i++)
                    {
                        moneyGained += enemies[i].moneyOnDefeat;
                        if (enemies[i].droppedItem != null)
                            Console.WriteLine($"The enemy drops a {enemies[i].droppedItem.name}.");
                            Player.inventory.Add(enemies[i].droppedItem);
                    }

                    Console.WriteLine($"You win and get their money!\nYou robbed them and got {moneyGained} of their money.");
                    
                    Player.money += moneyGained;
                    System.Threading.Thread.Sleep(2000);
                    break;
                }
            } 
        }
    }
}
