class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        RunAdapter();
        RunDecorator();
        RunBridge();
        RunProxy();
        RunComposite();
        RunFlyweight();

        Console.ReadKey();
    }

    //Adapter 
    static void RunAdapter()
    {
        Console.WriteLine("===== ADAPTER =====");

        Logger consoleLogger = new Logger();
        consoleLogger.Log("Це звичайне повідомлення.");
        consoleLogger.Warn("Це попередження.");
        consoleLogger.Error("Це помилка!");

        Console.WriteLine();

        FileLoggerAdapter fileLogger = new FileLoggerAdapter("log.txt");
        fileLogger.Log("Файл: звичайне повідомлення");
        fileLogger.Warn("Файл: попередження");
        fileLogger.Error("Файл: помилка");

        Console.WriteLine("Повідомлення записані в log.txt");
        Console.WriteLine();
    }

    // Decorator 
    static void RunDecorator()
    {
        Console.WriteLine("===== DECORATOR =====");

        Hero warrior = new Warrior("Артур");

        Console.WriteLine("=== Базові характеристики героя ===");
        warrior.ShowStats();

        Console.WriteLine();

        Hero equippedWarrior = new Armor(new Weapon(new Artifact(warrior)));

        Console.WriteLine("=== Герой з інвентарем ===");
        equippedWarrior.ShowStats();

        Console.WriteLine();
        Console.WriteLine("=== Mage з артефактом та бронею ===");

        Hero mage = new Mage("Мерлін");
        Hero equippedMage = new Armor(new Artifact(mage));
        equippedMage.ShowStats();

        Console.WriteLine();
    }

    // Bridge 
    static void RunBridge()
    {
        Console.WriteLine("===== BRIDGE =====");

        IRenderer vector = new VectorRenderer();
        IRenderer raster = new RasterRenderer();

        Shape circleVector = new Circle(vector);
        Shape squareVector = new Square(vector);
        Shape triangleVector = new Triangle(vector);

        Console.WriteLine("=== Векторна графіка ===");
        circleVector.Draw();
        squareVector.Draw();
        triangleVector.Draw();

        Console.WriteLine();

        Shape circleRaster = new Circle(raster);
        Shape squareRaster = new Square(raster);
        Shape triangleRaster = new Triangle(raster);

        Console.WriteLine("=== Растрова графіка ===");
        circleRaster.Draw();
        squareRaster.Draw();
        triangleRaster.Draw();

        Console.WriteLine();
    }

    //Proxy
    static void RunProxy()
    {
        Console.WriteLine("===== PROXY =====");

        string filePath = "test.txt";

        Console.WriteLine("=== SmartTextChecker ===");
        SmartTextReader reader = new SmartTextReader(filePath);
        SmartTextChecker checker = new SmartTextChecker(reader);
        char[][] content = checker.ReadFile();

        Console.WriteLine();
        Console.WriteLine("=== SmartTextReaderLocker ===");

        SmartTextReaderLocker locker = new SmartTextReaderLocker(reader, @"\.txt$");
        char[][] allowed = locker.ReadFile();

        SmartTextReader forbiddenReader = new SmartTextReader("secret.dat");
        SmartTextReaderLocker locker2 = new SmartTextReaderLocker(forbiddenReader, @"\.txt$");
        char[][] denied = locker2.ReadFile();

        Console.WriteLine();
    }

    //Composite 
    static void RunComposite()
    {
        Console.WriteLine("===== COMPOSITE =====");

        LightElementNode ul = new LightElementNode("ul", DisplayType.Block);
        ul.Classes.Add("list");

        LightElementNode li1 = new LightElementNode("li", DisplayType.Block);
        li1.AddChild(new LightTextNode("Перший елемент"));

        LightElementNode li2 = new LightElementNode("li", DisplayType.Block);
        li2.AddChild(new LightTextNode("Другий елемент"));

        LightElementNode li3 = new LightElementNode("li", DisplayType.Block);
        li3.AddChild(new LightTextNode("Третій елемент"));

        ul.AddChild(li1);
        ul.AddChild(li2);
        ul.AddChild(li3);

        Console.WriteLine("=== OuterHTML ===");
        Console.WriteLine(ul.OuterHTML);

        Console.WriteLine("\n=== InnerHTML ===");
        Console.WriteLine(ul.InnerHTML);

        Console.WriteLine();
    }

    // Flyweight
    static void RunFlyweight()
    {
        Console.WriteLine("===== FLYWEIGHT =====");

        string[] bookLines = new string[]
        {
            "Моя книга",
            "Вступ",
            " Це перший абзац, який починається з пробілу.",
            "Другий рядок звичайний.",
            "Коротко",
            " Ще один цитатний абзац."
        };

        Console.WriteLine("=== Створюємо HTML дерево ===");

        long memBefore = GC.GetTotalMemory(true);
        LightElementNode htmlTree = BookParser.ParseText(bookLines);
        long memAfter = GC.GetTotalMemory(true);

        Console.WriteLine("=== OuterHTML повного дерева ===");
        Console.WriteLine(htmlTree.OuterHTML);

        Console.WriteLine();
        Console.WriteLine($"Зайнята пам'ять приблизно: {memAfter - memBefore} байт");

        Console.WriteLine();
        Console.WriteLine($"Кількість дочірніх елементів кореня: {htmlTree.ChildCount}");

        Console.WriteLine();
    }
}