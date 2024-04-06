namespace ReachZen.API.DTOs;

public record class UpdateGoalDTO(string Name, string Description, DateOnly StartingDate, DateOnly DueDate);
