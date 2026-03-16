class VectorRenderer : IRenderer
{
    public void RenderCircle()
    {
        Console.WriteLine("Drawing Circle as vectors");
    }

    public void RenderSquare()
    {
        Console.WriteLine("Drawing Square as vectors");
    }

    public void RenderTriangle()
    {
        Console.WriteLine("Drawing Triangle as vectors");
    }
}

class RasterRenderer : IRenderer
{
    public void RenderCircle()
    {
        Console.WriteLine("Drawing Circle as pixels");
    }

    public void RenderSquare()
    {
        Console.WriteLine("Drawing Square as pixels");
    }

    public void RenderTriangle()
    {
        Console.WriteLine("Drawing Triangle as pixels");
    }
}
