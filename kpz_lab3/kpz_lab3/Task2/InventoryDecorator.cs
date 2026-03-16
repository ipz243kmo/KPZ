abstract class InventoryDecorator : Hero
{
    protected Hero hero;

    public InventoryDecorator(Hero hero) : base(hero.Name)
    {
        this.hero = hero;
    }

    public override void ShowStats()
    {
        hero.ShowStats();
    }
}
