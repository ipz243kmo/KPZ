class BookParser
{
    public static LightElementNode ParseText(string[] lines)
    {
        LightElementNode root = new LightElementNode("div");
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            LightElementNode tagNode;

            if (i == 0)
            {
                tagNode = new LightElementNode("h1");
            }
            else if (line.Trim().Length < 20)
            {
                tagNode = new LightElementNode("h2");
            }
            else if (line.StartsWith(" "))
            {
                tagNode = new LightElementNode("blockquote");
            }
            else
            {
                tagNode = new LightElementNode("p");
            }

            tagNode.AddChild(new LightTextNode(line));
            root.AddChild(tagNode);
        }

        return root;
    }
}
