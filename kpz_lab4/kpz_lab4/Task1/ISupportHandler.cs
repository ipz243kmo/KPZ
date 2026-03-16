interface ISupportHandler
{
    void SetNext(ISupportHandler next);
    void HandleRequest(int level);
}
