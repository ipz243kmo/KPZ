class Armor : InventoryDecorator
{
    public Armor(Hero hero) : base(hero) { }

    public override void ShowStats()
    {
        hero.ShowStats();
        Console.WriteLine(" + Носить броню: +20 до захисту");
    }
}

class Weapon : InventoryDecorator
{
    public Weapon(Hero hero) : base(hero) { }

    public override void ShowStats()
    {
        hero.ShowStats();
        Console.WriteLine(" + Озброєний зброєю: +15 до атаки");
    }
}

class Artifact : InventoryDecorator
{
    public Artifact(Hero hero) : base(hero) { }

    public override void ShowStats()
    {
        hero.ShowStats();
        Console.WriteLine(" + Має артефакт: +10 до магії");
    }
}
