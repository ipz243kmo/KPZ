using System.Text.RegularExpressions;

class SmartTextReaderLocker
{
    private SmartTextReader reader;
    private Regex accessRegex;

    public SmartTextReaderLocker(SmartTextReader reader, string pattern)
    {
        this.reader = reader;
        accessRegex = new Regex(pattern, RegexOptions.IgnoreCase);
    }

    public char[][] ReadFile()
    {
        if (!accessRegex.IsMatch(reader.FileName))
        {
            Console.WriteLine("Access denied!");
            return null;
        }

        return reader.ReadFile();
    }
}
