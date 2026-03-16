class ExpertSupport : SupportHandler
{
    public override void HandleRequest(int level)
    {
        if (level == 4)
        {
            Console.WriteLine("Вас обслуговує Експертна підтримка.");
        }
        else
        {
            Console.WriteLine("Не вдалося знайти відповідний рівень підтримки.");
        }
    }
}
