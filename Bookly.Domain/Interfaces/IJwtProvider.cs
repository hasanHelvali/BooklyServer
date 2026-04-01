using Bookly.Domain.Entities;
namespace Bookly.Domain.Interfaces;
public interface IJwtProvider
{
    string GenerateToken(User user);
}
