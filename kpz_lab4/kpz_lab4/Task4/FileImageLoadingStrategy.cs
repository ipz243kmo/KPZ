class FileImageLoadingStrategy : IImageLoadingStrategy
{
    public void LoadImage(string href)
    {
        Console.WriteLine($"Завантаження з файлової системи: {href}");
    }
}
