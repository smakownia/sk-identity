using Smakownia.Identity.Domain.Exceptions;

namespace Smakownia.Identity.Application.Exceptions;

public class IdentityWithSameEmailExistsException : ConflictException
{
    public IdentityWithSameEmailExistsException(string email) : base($"Identity with email: '{email}' already exists") { }
}
