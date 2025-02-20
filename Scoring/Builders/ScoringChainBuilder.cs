using Scoring.Levels;

namespace Scoring.Builders;

public class ScoringChainBuilder
{
    private BusinessPlanLevel _businessPlanLevel;

    public ScoringChainBuilder SetPlan(BusinessPlanLevel businessPlanLevel)
    {
        _businessPlanLevel = businessPlanLevel;
        return this;
    }
 
     
    public ScoringHandler Build()
    {
        if (_businessPlanLevel == BusinessPlanLevel.None || 
            !_businessPlanLevel.HasFlag(BusinessPlanLevel.Employee))
            throw new InvalidOperationException("Invalid b plan id!");
 
        var firstHandler = new EmployeeScoringHandler();


        ScoringHandler handler = firstHandler;
        if (_businessPlanLevel.HasFlag(BusinessPlanLevel.Shahkar))
        {
            handler = handler.SetNext(new ShahkarScoringHandler());
        }
         
        if (_businessPlanLevel.HasFlag(BusinessPlanLevel.Sabegheh))
        {
            handler = handler.SetNext(new SabeghehScoringHandler());
        }
         
        if (_businessPlanLevel.HasFlag(BusinessPlanLevel.Finance))
        {
            handler = handler.SetNext(new FinanceScoringHandler());

        }

        if (_businessPlanLevel.HasFlag(BusinessPlanLevel.AlivePerson))
        {
            handler = handler.SetNext(new AlivePersonScoringHandler());

        }

        return firstHandler;
    }

}



