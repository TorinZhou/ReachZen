namespace ReachZen.API.DTOs;

public record class GoalDTO(int Id, string Name, string Description, DateOnly StartingDate, DateOnly DueDate);
