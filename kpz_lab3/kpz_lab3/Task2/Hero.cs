using System;
abstract class Hero
{
    public string Name { get; set; }

    public Hero(string name)
    {
        Name = name;
    }

    public abstract void ShowStats();
}
class Warrior : Hero
{
    public Warrior(string name) : base(name) { }

    public override void ShowStats()
    {
        Console.WriteLine($"{Name} – Warrior: сила 10, магія 2, здоров'я 100");
    }
}
class Mage : Hero
{
    public Mage(string name) : base(name) { }

    public override void ShowStats()
    {
        Console.WriteLine($"{Name} – Mage: сила 3, магія 12, здоров'я 80");
    }
}
class Palladin : Hero
{
    public Palladin(string name) : base(name) { }

    public override void ShowStats()
    {
        Console.WriteLine($"{Name} – Palladin: сила 7, магія 5, здоров'я 90");
    }
}
