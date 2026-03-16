using System.Reflection.Emit;

class Program
{
    static void Main(string[] args)
    {
        RunAbstractFactory();
        RunFactoryMethod();
        RunSingleton();
        RunPrototype();
        RunBuilder();

        Console.ReadKey();
    }

    //Abstract Factory
    static void RunAbstractFactory()
    {
        Console.WriteLine("\n=== Abstract Factory ===");

        IDeviceFactory iprone = new IProneFactory();
        IDeviceFactory kiaomi = new KiaomiFactory();
        IDeviceFactory balaxy = new BalaxyFactory();

        ShowDevices(iprone, "IProne");
        ShowDevices(kiaomi, "Kiaomi");
        ShowDevices(balaxy, "Balaxy");
    }

    static void ShowDevices(IDeviceFactory factory, string brand)
    {
        Console.WriteLine($"\n--- {brand} devices ---");

        Console.WriteLine(factory.CreateLaptop().GetModel());
        Console.WriteLine(factory.CreateNetbook().GetModel());
        Console.WriteLine(factory.CreateEBook().GetModel());
        Console.WriteLine(factory.CreateSmartphone().GetModel());
    }

    // Factory Method
    static void RunFactoryMethod()
    {
        Console.WriteLine("\n=== Factory Method ===");

        SubscriptionProvider website = new WebSite();
        SubscriptionProvider mobileApp = new MobileApp();
        SubscriptionProvider manager = new ManagerCall();

        Subscription domestic = website.CreateSubscription(SubscriptionType.Domestic);
        domestic.DisplayInfo();

        Subscription educational = mobileApp.CreateSubscription(SubscriptionType.Educational);
        educational.DisplayInfo();

        Subscription premium = manager.CreateSubscription(SubscriptionType.Premium);
        premium.DisplayInfo();
    }

    //Singleton 
    static void RunSingleton()
    {
        Console.WriteLine("\n=== Singleton ===");

        var auth1 = Authenticator.Instance;
        var auth2 = Authenticator.Instance;

        Console.WriteLine($"auth1 == auth2: {auth1 == auth2}");

        auth1.Authenticate("user1", "pass1");

        var advAuth = new AdvancedAuthenticator();
        advAuth.AdvancedAuthenticate("user2");
    }

    //Prototype 
    static void RunPrototype()
    {
        Console.WriteLine("\n=== Prototype ===");

        Virus parent = new Virus("Alpha", "Corona", 5, 1.2);
        Virus child1 = new Virus("Beta", "Corona", 2, 0.8);
        Virus child2 = new Virus("Gamma", "Corona", 1, 0.5);
        Virus grandChild = new Virus("Delta", "Corona", 0, 0.2);

        child1.AddChild(grandChild);
        parent.AddChild(child1);
        parent.AddChild(child2);

        Console.WriteLine("Original Virus Family:");
        parent.Print();

        Virus clonedParent = parent.Clone();

        Console.WriteLine("\nCloned Virus Family:");
        clonedParent.Print();

        Console.WriteLine($"\nparent == clonedParent: {parent == clonedParent}");
        Console.WriteLine($"parent.Children[0] == clonedParent.Children[0]: {parent.Children[0] == clonedParent.Children[0]}");
    }

    // Builder 
    static void RunBuilder()
    {
        Console.WriteLine("\n=== Builder ===");

        var director = new CharacterDirector();

        var heroBuilder = new HeroBuilder();
        director.CreateHero(heroBuilder);
        var hero = heroBuilder.Build();

        var enemyBuilder = new EnemyBuilder();
        director.CreateEnemy(enemyBuilder);
        var enemy = enemyBuilder.Build();

        Console.WriteLine("Hero:");
        hero.Print();

        Console.WriteLine("Enemy:");
        enemy.Print();
    }
}