
public class User
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public required string Role { get; set; } 

    public bool IsAdmin => string.Equals(Role, "admin", StringComparison.OrdinalIgnoreCase);
    private Migrant? _migrantProfile;

    public Migrant? MigrantProfile
    {
        get => IsAdmin ? null : _migrantProfile ??= new Migrant();
        set => _migrantProfile = value;
    }
}

