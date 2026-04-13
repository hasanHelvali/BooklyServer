using Bookly.Domain.Abstractions;
using Bookly.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Bookly.Domain.Entities;
public class User:IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    //public string Email { get; set; } = string.Empty;
    //public string PasswordHash { get; set; } = string.Empty;
    //public UserRole Role { get; set; } = UserRole.Customer;
    public bool IsActive { get; set; } = true;
    public string NotHashPass { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiresAt { get; set; }
}
