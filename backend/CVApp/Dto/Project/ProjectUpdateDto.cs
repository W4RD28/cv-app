namespace CVApp.Dto.Project;

public class ProjectUpdateDto
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Url { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}