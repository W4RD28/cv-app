namespace CVApp.Dto.Education;

public class EducationCreateDto
{
    public int UserId { get; set; }

    public string Institution { get; set; }

    public string Area { get; set; }

    public string StudyType { get; set; }

    public string Gpa { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}