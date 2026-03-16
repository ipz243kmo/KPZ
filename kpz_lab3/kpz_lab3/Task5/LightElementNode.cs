using System.Text;

enum DisplayType { Block, Inline }
enum CloseType { SelfClosing, Normal }

class LightElementNode : LightNode
{
    public string TagName { get; set; }
    public DisplayType Display { get; set; }
    public CloseType Close { get; set; }
    public List<string> Classes { get; set; } = new List<string>();
    public List<LightNode> Children { get; set; } = new List<LightNode>();

    public LightElementNode(string tagName, DisplayType display = DisplayType.Block, CloseType close = CloseType.Normal)
    {
        TagName = tagName;
        Display = display;
        Close = close;
    }

    public void AddChild(LightNode child)
    {
        Children.Add(child);
    }

    public int ChildCount => Children.Count;

    public override string InnerHTML
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            foreach (var child in Children)
            {
                sb.Append(child.OuterHTML);
            }
            return sb.ToString();
        }
    }

    public override string OuterHTML
    {
        get
        {
            string classAttr = Classes.Count > 0 ? $" class=\"{string.Join(" ", Classes)}\"" : "";
            if (Close == CloseType.SelfClosing)
            {
                return $"<{TagName}{classAttr}/>";
            }
            else
            {
                return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
            }
        }
    }
}
