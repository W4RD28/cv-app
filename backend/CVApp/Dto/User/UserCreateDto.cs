namespace CVApp.Dto.User;

public class UserCreateDto
{
    public string Name { get; set; }

    public string? Label { get; set; }

    public string? Email { get; set; }

    public string? Location { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Summary { get; set; }
}