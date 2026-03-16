class TextDocument
{
    public string Content { get; set; }

    public TextDocument(string text)
    {
        Content = text;
    }

    public DocumentMemento Save()
    {
        return new DocumentMemento(Content);
    }

    public void Restore(DocumentMemento memento)
    {
        Content = memento.Content;
    }
}
