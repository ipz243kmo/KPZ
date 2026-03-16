using LightHTML;
class LightImageNode : LightNode
{
    public string Href { get; set; }

    private IImageLoadingStrategy strategy;

    public LightImageNode(string href)
    {
        Href = href;

        if (href.StartsWith("http"))
        {
            strategy = new NetworkImageLoadingStrategy();
        }
        else
        {
            strategy = new FileImageLoadingStrategy();
        }
    }

    public void Load()
    {
        strategy.LoadImage(Href);
    }

    public override string OuterHTML => $"<img src=\"{Href}\" />";
    public override string InnerHTML => "";
}
