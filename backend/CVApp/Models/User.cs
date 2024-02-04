namespace CVApp.Models;

public class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Label { get; set; }

    public string? Email { get; set; }

    public string? Location { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Summary { get; set; }

    public List<Skill>? Skills { get; set; }

    public List<Work>? Works { get; set; }

    public List<Project>? Projects { get; set; }

    public List<Certification>? Certifications { get; set; }

    public List<Language>? Languages { get; set; }

    public List<Social>? Socials { get; set; }

    public List<Education>? Educations { get; set; }
}