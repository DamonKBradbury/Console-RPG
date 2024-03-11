using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Items
    {
        public bool equiped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, bool equiped) : base(name, description, shopPrice, sellPrice)
        {
            this.equiped = equiped;
        }
    }

    class Armor : Equipment
    {
        public int defence;
        protected Armor(string name, string description, int shopPrice, int sellPrice, bool equiped, int defence) : base(name, description, shopPrice, sellPrice, equiped)
        {
            this.defence = defence;
        }

        public override void Use(Entity user, Entity target)
        {
            this.equiped = !this.equiped;

            if (this.equiped)
            {
            target.stats.defence += this.defence;
            }
            ///among us
            else
            {
            target.stats.defence -= this.defence;
            }
        }
    }

    class Weapon : Equipment
    {
        public static Weapon Zanpakuto = new Weapon("Zanpakuto", "deals 25 more damage than regular attack", 1000, 500, false, 25);

        public int attack;
        protected Weapon(string name, string description, int shopPrice, int sellPrice, bool equiped, int attack) : base(name, description, shopPrice, sellPrice, equiped)
        {
            this.attack = attack;
        }

        public override void Use(Entity user, Entity target)
        {
            this.equiped = !this.equiped;

            if (this.equiped)
            {
            target.stats.attack += this.attack;
            }

            else
            {
            target.stats.attack -= this.attack;
            }
        }
    }
}
