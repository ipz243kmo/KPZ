using static System.Net.Mime.MediaTypeNames;

class AdminSupport : SupportHandler
{
    public override void HandleRequest(int level)
    {
        if (level == 3)
        {
            Console.WriteLine("Вас обслуговує Адміністратор.");
        }
        else if (next != null)
        {
            next.HandleRequest(level);
        }
    }
}
