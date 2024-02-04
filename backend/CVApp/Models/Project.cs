namespace CVApp.Models;

public class Project
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Url { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}