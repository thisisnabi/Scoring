
namespace Scoring.Levels;

public class FinanceScoringHandler : ScoringHandler
{
    public override Task<int> HandleAsync(UserScoringContext userScoringContext)
    {
        // chack shahkar external system

        //if check resull was succeed
        userScoringContext.Score += 100;

        if (NextHandler is null)
            return Task.FromResult(userScoringContext.Score);

        return NextHandler.HandleAsync(userScoringContext);
    }
}
