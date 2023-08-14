using System.ComponentModel.DataAnnotations;

namespace Smakownia.Identity.Application.Requests;

public sealed record RegisterRequest
{
    public RegisterRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [MinLength(8)]
    public string Password { get; init; }
}
