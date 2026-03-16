class NetworkImageLoadingStrategy : IImageLoadingStrategy
{
    public void LoadImage(string href)
    {
        Console.WriteLine($"Завантаження з мережі: {href}");
    }
}
