using static System.Net.Mime.MediaTypeNames;

class BasicSupport : SupportHandler
{
    public override void HandleRequest(int level)
    {
        if (level == 1)
        {
            Console.WriteLine("Вас обслуговує Базова підтримка.");
        }
        else if (next != null)
        {
            next.HandleRequest(level);
        }
    }
}
