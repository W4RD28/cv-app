namespace CVApp.Models;

public class Certification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; }

    public string? Authority { get; set; }

    public string? Description { get; set; }

    public string? LicenseNumber { get; set; }

    public string? Url { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly? ExpirationDate { get; set; }
}