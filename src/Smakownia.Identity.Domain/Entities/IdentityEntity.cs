namespace Smakownia.Identity.Domain.Entities;

public class IdentityEntity
{
    public IdentityEntity(string email, string password)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
    }

    protected IdentityEntity() { }

    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}
