
namespace Scoring.Levels;

public class EmployeeScoringHandler : ScoringHandler
{
    public override Task<int> HandleAsync(UserScoringContext userScoringContext)
    {
        // check HRS in snapp
       
        // if check resull was succeed
        userScoringContext.Score += 100;

        if (NextHandler is null)
            return Task.FromResult(userScoringContext.Score);

        return NextHandler.HandleAsync(userScoringContext);
    }
}
