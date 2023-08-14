namespace Smakownia.Identity.Domain.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException() : base("Unauthorized") { }
}
