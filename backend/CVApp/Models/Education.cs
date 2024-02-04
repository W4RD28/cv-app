namespace CVApp.Models;

public class Education
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Institution { get; set; }

    public string Area { get; set; }

    public string StudyType { get; set; }

    public float? GPA { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}