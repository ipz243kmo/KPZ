using System.Text;
using DesignPatterns.Mediator;

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        RunChainOfResponsibility();
        RunMediator();
        RunObserver();
        RunLazyLoading();
        RunMemento();

        Console.ReadKey();
    }

    // Chain of Responsibility 
    static void RunChainOfResponsibility()
    {
        Console.WriteLine("===== CHAIN OF RESPONSIBILITY =====");

        BasicSupport basic = new BasicSupport();
        TechnicalSupport tech = new TechnicalSupport();
        AdminSupport admin = new AdminSupport();
        ExpertSupport expert = new ExpertSupport();

        basic.SetNext(tech);
        tech.SetNext(admin);
        admin.SetNext(expert);

        Console.WriteLine("1 - Проблеми з паролем");
        Console.WriteLine("2 - Проблеми з програмою");
        Console.WriteLine("3 - Проблеми з доступом");
        Console.WriteLine("4 - Складна технічна проблема");

        Console.Write("Ваш вибір: ");
        int choice = int.Parse(Console.ReadLine());

        basic.HandleRequest(choice);

        Console.WriteLine();
    }

    // Mediator
    static void RunMediator()
    {
        Console.WriteLine("===== MEDIATOR =====");

        Runway runway1 = new Runway();
        Runway runway2 = new Runway();

        var runways = new List<Runway> { runway1, runway2 };

        CommandCentre commandCentre = new CommandCentre(runways);

        Aircraft aircraft1 = new Aircraft("Boeing 737", commandCentre);
        Aircraft aircraft2 = new Aircraft("Airbus A320", commandCentre);

        aircraft1.Land();
        aircraft2.Land();

        aircraft1.TakeOff();
        aircraft2.TakeOff();

        Console.WriteLine();
    }

    // Observer 
    static void RunObserver()
    {
        Console.WriteLine("===== OBSERVER =====");

        LightElementNode button = new LightElementNode("button", DisplayType.Inline);
        button.AddChild(new LightTextNode("Натисни мене"));

        button.AddEventListener("click", () =>
        {
            Console.WriteLine("Кнопку натиснули!");
        });

        button.AddEventListener("mouseover", () =>
        {
            Console.WriteLine("Курсор над кнопкою!");
        });

        Console.WriteLine("HTML кнопки:");
        Console.WriteLine(button.OuterHTML);

        Console.WriteLine("\n--- Імітація подій ---");

        button.TriggerEvent("mouseover");
        button.TriggerEvent("click");

        Console.WriteLine();
    }

    //Lazy Loading
    static void RunLazyLoading()
    {
        Console.WriteLine("===== LAZY LOADING =====");

        LightImageNode localImage = new LightImageNode("images/photo.png");
        LightImageNode webImage = new LightImageNode("https://example.com/photo.jpg");

        Console.WriteLine("HTML елемент:");
        Console.WriteLine(localImage.OuterHTML);
        Console.WriteLine(webImage.OuterHTML);

        Console.WriteLine("\nЗавантаження зображень:");

        localImage.Load();
        webImage.Load();

        Console.WriteLine();
    }

    //  Memento
    static void RunMemento()
    {
        Console.WriteLine("===== MEMENTO =====");

        TextDocument doc = new TextDocument("Hello");
        TextEditor editor = new TextEditor(doc);

        editor.Show();

        editor.Write(" world");
        editor.Show();

        editor.Write("!!!");
        editor.Show();

        Console.WriteLine("Undo:");

        editor.Undo();
        editor.Show();

        editor.Undo();
        editor.Show();

        Console.WriteLine();
    }
}