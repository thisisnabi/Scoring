namespace Scoring.Levels;

public abstract class ScoringHandler
{
    protected ScoringHandler NextHandler { get; set; }
     
    public ScoringHandler SetNext(ScoringHandler nextHandler)
    {
        NextHandler = nextHandler;
        return nextHandler;
    }
     
    public abstract Task<int> HandleAsync(UserScoringContext userScoringContext);
}
