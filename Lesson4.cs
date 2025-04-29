using System;
namespace HeroGame
{
    class Hero
    {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public Hero(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public virtual void Attack(Hero target)
        {
            Console.WriteLine($"{Name} атакует {target.Name}, нанося {Damage} урона");
            target.TakeDamage(Damage);
        }
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} получает {damage} урона, здоровье теперь {Health}");
        }
    }
    class MeleeHero : Hero
    {
        public MeleeHero(string name, int health, int damage)
            : base(name, health, damage)
        {
        }
        public override void Attack(Hero target)
        {
            int increasedDamage = (int)(Damage * 1.2);
            Console.WriteLine($"{Name} атакует {target.Name}, нанося {increasedDamage} урона (ближний бой)");
            target.TakeDamage(increasedDamage);
        }
    }
    class RangedHero : Hero
    {
        public RangedHero(string name, int health, int damage)
            : base(name, health, damage)
        {
        }
        public override void TakeDamage(int damage)
        {
            int reducedDamage = (int)(damage * 0.7);
            Health -= reducedDamage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} получает {reducedDamage} урона, здоровье теперь {Health}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MeleeHero axe = new MeleeHero("Axe", 1000, 100);
            RangedHero drowRanger = new RangedHero("Drow Ranger", 1200, 100);
            Console.WriteLine($"Создан герой: {axe.Name} (ближний бой)");
            Console.WriteLine($"Создан герой: {drowRanger.Name} (дальний бой)");
            Console.WriteLine();
            axe.Attack(drowRanger);
            Console.WriteLine();
            drowRanger.Attack(axe);
            Console.WriteLine();
            Console.WriteLine($"{axe.Name} здоровье: {axe.Health}");
            Console.WriteLine($"{drowRanger.Name} здоровье: {drowRanger.Health}");
        }
    }
}