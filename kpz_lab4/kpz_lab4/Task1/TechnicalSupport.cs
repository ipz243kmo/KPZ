using static System.Net.Mime.MediaTypeNames;

class TechnicalSupport : SupportHandler
{
    public override void HandleRequest(int level)
    {
        if (level == 2)
        {
            Console.WriteLine("Вас обслуговує Технічна підтримка.");
        }
        else if (next != null)
        {
            next.HandleRequest(level);
        }
    }
}
