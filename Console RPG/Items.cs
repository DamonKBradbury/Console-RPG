using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Items
    {

        public string name;
        public string description;
        public int shopPrice;
        public int sellPrice;

        public Items(string name, string description, int shopPrice, int sellPrice)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.sellPrice = sellPrice;
        }

        public abstract void Use(Entity user, Entity target);

    }

    class HealthPotionItem : Items
    {
        public static HealthPotionItem Potion1 = new HealthPotionItem("Lesser Health Potion", "Heals 3 hp", 10, 5, 3);
        public static HealthPotionItem Pizza = new HealthPotionItem("Pepperoni pizza", "Heals 4 hp", 16, 8, 4);
        public static HealthPotionItem meat = new HealthPotionItem("Meat", "Heals 2 hp", 0, 1, 2);
        public static HealthPotionItem burger = new HealthPotionItem("Burger", "Heals 5 hp", 18, 9, 5);
        
        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int sellPrice, int healAmount) : base(name, description, shopPrice, sellPrice)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHp += this.healAmount;
            Console.WriteLine(target.name + " gets healed!");
        }

    }
    class DamageItems : Items
    {

        public static DamageItems throwingKnife = new DamageItems("Throwing knife", "deals 2 damage more than regular attack", 10, 5, 2);
        public static DamageItems grenade = new DamageItems("Grenade", "Deals 8 more damage than regular attack", 16, 8, 8);
        public static DamageItems thermonucularBomb = new DamageItems("Thermal Nuclear Bomb", "Deals 100 more damage than regular attack", 1, 100000, 100);

        public int damage;

        public DamageItems(string name, string description, int shopPrice, int sellPrice, int damage) : base(name, description, shopPrice, sellPrice)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHp -= (this.damage + user.stats.attack);
            Console.WriteLine(target.name + " gets damaged!");
        }
    }
    class SellItems : Items
    {
        public static SellItems ironOre = new SellItems("Iron Ore", "A chunk of iron ore (does nothing)", 0, 1);
        public static SellItems goldOre = new SellItems("Gold Ore", "A chunk of golf ore (does nothing)", 0, 5);
        public static SellItems diamond = new SellItems("Diamond", "A chunk of diamond (does nothing)", 0, 10);
        public static SellItems coal = new SellItems("Coal", "A chunk of coal (gives Black Lung if you mine 10000 coal)", 0, 5);
        public SellItems(string name, string description, int shopPrice, int sellPrice) : base(name, description, shopPrice, sellPrice)
        {
            
        }
        public override void Use(Entity user, Entity target)
        {
            Console.WriteLine($"You throw {name} and nothing happened");
        }
    }
}
