namespace Scoring;

public class BusinessPlan
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public BusinessPlanLevel Plans { get; set; }
}


[Flags]
public enum BusinessPlanLevel
{ 
    None,
    Employee,
    Shahkar,
    Sabegheh,
    Finance,
    AlivePerson
}