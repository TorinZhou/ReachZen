using System.Diagnostics.CodeAnalysis;
using ReachZen.API.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


const string GetGoalEndpointName = "GetGoal";
var goals = new List<GoalDTO>()
{
    new(1, "Learn React", "By doing this, I can build frontend apps", new DateOnly(2024, 04, 06), new DateOnly(2024, 04, 19)),
    new(2, "Learn ASP.Net Core Minimal API", "By doing this, I can build backend apps", new DateOnly(2024, 04, 06), new DateOnly(2024, 04, 19)),
    new(3, "Learn Math", "By doing this, I can pass exams", new DateOnly(2024, 04, 06), new DateOnly(2024, 04, 19)),
};


// GET /goals
app.MapGet("/goals", () => goals);

// GET /goals/1
app.MapGet("/goals/{id}", (int id) =>
{
    GoalDTO? goal = goals.Find(goal => goal.Id == id);

    return goal is null ? Results.NotFound() : Results.Ok(goal);
}).WithName(GetGoalEndpointName);

// POST /goals
app.MapPost("/goals", (CreateGoalDTO newGoal) =>
{
    int id = goals.Count + 1;
    var goal = new GoalDTO(id, newGoal.Name, newGoal.Description, newGoal.StartingDate, newGoal.DueDate);
    goals.Add(goal);
    return Results.CreatedAtRoute(GetGoalEndpointName, new { id = goal.Id }, goal);
});

// PUT /goals/4
app.MapPut("/goals/{id}", (int id, UpdateGoalDTO updatedGoal) =>
{
    int index = goals.FindIndex(goal => goal.Id == id);

    if (index == -1) return Results.NotFound();

    var goal = new GoalDTO(id, updatedGoal.Name, updatedGoal.Description, updatedGoal.StartingDate, updatedGoal.DueDate);
    goals[index] = goal;
    return Results.NoContent();
});

// DELETE /goals/1
app.MapDelete("/goals/{id}", (int id) =>
{
    goals.RemoveAll(goal => goal.Id == id);

    return Results.NoContent();
});

app.Run();
