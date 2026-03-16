class SmartTextChecker
{
    private SmartTextReader reader;

    public SmartTextChecker(SmartTextReader reader)
    {
        this.reader = reader;
    }

    public char[][] ReadFile()
    {
        Console.WriteLine($"Opening file: {reader.FileName} ...");
        char[][] content = reader.ReadFile();
        Console.WriteLine("File read successfully!");
        int totalLines = content.Length;
        int totalChars = 0;
        foreach (var line in content)
        {
            totalChars += line.Length;
        }
        Console.WriteLine($"Lines: {totalLines}, Characters: {totalChars}");
        Console.WriteLine("Closing file...");
        return content;
    }
}
