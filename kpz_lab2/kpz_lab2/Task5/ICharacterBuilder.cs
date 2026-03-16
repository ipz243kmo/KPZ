using System;
using System.Collections.Generic;

#region Builder Interface

public interface ICharacterBuilder<TBuilder>
{
    TBuilder SetHeight(int height);
    TBuilder SetBuild(string build);
    TBuilder SetHairColor(string hairColor);
    TBuilder SetEyeColor(string eyeColor);
    TBuilder SetClothes(string clothes);
    TBuilder AddInventory(string item);
    Character Build();
}

#endregion

#region Hero Builder

public class HeroBuilder : ICharacterBuilder<HeroBuilder>
{
    private Character _hero = new Character();

    public HeroBuilder SetHeight(int height) { _hero.Height = height; return this; }
    public HeroBuilder SetBuild(string build) { _hero.Build = build; return this; }
    public HeroBuilder SetHairColor(string hairColor) { _hero.HairColor = hairColor; return this; }
    public HeroBuilder SetEyeColor(string eyeColor) { _hero.EyeColor = eyeColor; return this; }
    public HeroBuilder SetClothes(string clothes) { _hero.Clothes = clothes; return this; }
    public HeroBuilder AddInventory(string item) { _hero.Inventory.Add(item); return this; }

    public HeroBuilder AddGoodDeed(string deed) { _hero.GoodDeeds.Add(deed); return this; }

    public Character Build() { return _hero; }
}

#endregion

#region Enemy Builder

public class EnemyBuilder : ICharacterBuilder<EnemyBuilder>
{
    private Character _enemy = new Character();

    public EnemyBuilder SetHeight(int height) { _enemy.Height = height; return this; }
    public EnemyBuilder SetBuild(string build) { _enemy.Build = build; return this; }
    public EnemyBuilder SetHairColor(string hairColor) { _enemy.HairColor = hairColor; return this; }
    public EnemyBuilder SetEyeColor(string eyeColor) { _enemy.EyeColor = eyeColor; return this; }
    public EnemyBuilder SetClothes(string clothes) { _enemy.Clothes = clothes; return this; }
    public EnemyBuilder AddInventory(string item) { _enemy.Inventory.Add(item); return this; }

    public EnemyBuilder AddEvilDeed(string deed) { _enemy.EvilDeeds.Add(deed); return this; }

    public Character Build() { return _enemy; }
}

#endregion

#region Character class

public class Character
{
    public int Height { get; set; }
    public string Build { get; set; } = "";
    public string HairColor { get; set; } = "";
    public string EyeColor { get; set; } = "";
    public string Clothes { get; set; } = "";
    public List<string> Inventory { get; set; } = new List<string>();

    public List<string> GoodDeeds { get; set; } = new List<string>();
    public List<string> EvilDeeds { get; set; } = new List<string>();

    public void Print()
    {
        Console.WriteLine($"Height: {Height}, Build: {Build}, Hair: {HairColor}, Eyes: {EyeColor}, Clothes: {Clothes}");
        Console.WriteLine($"Inventory: {string.Join(", ", Inventory)}");
        if (GoodDeeds.Count > 0) Console.WriteLine($"Good Deeds: {string.Join(", ", GoodDeeds)}");
        if (EvilDeeds.Count > 0) Console.WriteLine($"Evil Deeds: {string.Join(", ", EvilDeeds)}");
        Console.WriteLine(new string('-', 40));
    }
}

#endregion

#region Director

public class CharacterDirector
{
    public void CreateHero(HeroBuilder builder)
    {
        builder.SetHeight(180)
               .SetBuild("Athletic")
               .SetHairColor("Blonde")
               .SetEyeColor("Blue")
               .SetClothes("Knight Armor")
               .AddInventory("Sword")
               .AddInventory("Shield")
               .AddGoodDeed("Saved the village")
               .AddGoodDeed("Defeated the dragon");
    }

    public void CreateEnemy(EnemyBuilder builder)
    {
        builder.SetHeight(190)
               .SetBuild("Muscular")
               .SetHairColor("Black")
               .SetEyeColor("Red")
               .SetClothes("Dark Robes")
               .AddInventory("Dark Sword")
               .AddInventory("Poison")
               .AddEvilDeed("Burned the village")
               .AddEvilDeed("Kidnapped the princess");
    }
}

#endregion
