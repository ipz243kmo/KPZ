using System;
using System.IO;
using System.Text.RegularExpressions;

class SmartTextReader
{
    private string filePath;

    public SmartTextReader(string path)
    {
        filePath = path;
    }

    public char[][] ReadFile()
    {
        string[] lines = File.ReadAllLines(filePath);
        char[][] result = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            result[i] = lines[i].ToCharArray();
        }
        return result;
    }

    public string FileName => filePath;
}
