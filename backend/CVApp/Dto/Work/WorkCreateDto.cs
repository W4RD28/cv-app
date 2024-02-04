namespace CVApp.Dto.Work;

public class WorkCreateDto
{
    public int UserId { get; set; }

    public string Company { get; set; }

    public string Position { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}