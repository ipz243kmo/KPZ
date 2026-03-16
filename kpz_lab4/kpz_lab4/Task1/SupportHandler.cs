abstract class SupportHandler : ISupportHandler
{
    protected ISupportHandler next;

    public void SetNext(ISupportHandler nextHandler)
    {
        next = nextHandler;
    }

    public abstract void HandleRequest(int level);
}
