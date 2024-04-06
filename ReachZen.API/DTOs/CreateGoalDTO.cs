namespace ReachZen.API.DTOs;

public record class CreateGoalDTO(string Name, string Description, DateOnly StartingDate, DateOnly DueDate);
