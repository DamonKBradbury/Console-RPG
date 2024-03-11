using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    struct Stats
    {
        public int attack;
        public int defence;
        public int magicAtk;
        public int magicDef;

        public Stats(int attack, int defence, int magicAtk, int magicDef)
        {
            this.attack = attack;
            this.defence = defence;
            this.magicAtk = magicAtk;
            this.magicDef = magicDef;
    }
    }
   
    abstract class Entity
    {
        public string name;
        public int currentHp, maxHp;
        public int currentMana, maxMana;
        public Stats stats;

        public Entity(string name, int hp, int mana, Stats stats)
        {
            this.name = name;
            this.currentHp = hp;
            this.maxHp = hp;
            this.currentMana = mana;
            this.maxMana = mana;
            this.stats = stats;
        }

        public abstract void DoTurn(List<Player> players, List<Enemy> enemies);

        public abstract Entity ChooseTarget(List<Entity> choices);

        public abstract void Attack(Entity target);
  
    } 
}
