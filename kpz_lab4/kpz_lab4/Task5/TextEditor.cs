using System.Collections.Generic;

class TextEditor
{
    private TextDocument document;
    private Stack<DocumentMemento> history = new Stack<DocumentMemento>();

    public TextEditor(TextDocument doc)
    {
        document = doc;
    }

    public void Write(string text)
    {
        history.Push(document.Save());
        document.Content += text;
    }

    public void Undo()
    {
        if (history.Count > 0)
        {
            var memento = history.Pop();
            document.Restore(memento);
        }
    }

    public void Show()
    {
        Console.WriteLine(document.Content);
    }
}
