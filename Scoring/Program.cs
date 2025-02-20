using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;
using Scoring;
using Scoring.Builders;
using Scoring.Levels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<ScoringChainBuilder>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/scoring/{plan_id}", async ([FromRoute(Name = "plan_id")]int Id,ScoringChainBuilder scoringChainBuilder) =>
{

    var plan = PlanBox.Plans.FirstOrDefault(pl => pl.Id == Id);
    if (plan is null)
        return Results.NotFound();

    scoringChainBuilder.SetPlan(plan.Plans);
    var starter = scoringChainBuilder.Build();

    var scoring = await starter.HandleAsync(new UserScoringContext
    {
        NationalCode = "2000000000",
        PhoneNumber = "3423532652345",
    });

    return Results.Ok($"User score is {scoring}");
});


app.Run();



public static class PlanBox
{

    public static ICollection<BusinessPlan> Plans = [
           new BusinessPlan{
                Id = 1,
                Title ="Credit",
                Plans = BusinessPlanLevel.Employee | BusinessPlanLevel.Shahkar
            },           new BusinessPlan{
             Id = 2,
                Title ="Insurance",
                Plans = BusinessPlanLevel.Employee | BusinessPlanLevel.Shahkar | BusinessPlanLevel.Sabegheh
            },
        ];
}