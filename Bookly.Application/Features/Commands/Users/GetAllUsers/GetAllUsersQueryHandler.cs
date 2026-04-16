using Bookly.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Bookly.Application.Features.Commands.Users.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
{
    private readonly UserManager<User> _userManager;

    public GetAllUsersQueryHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken
cancellationToken)
    {
        var users = _userManager.Users.ToList();

        var result = new List<GetAllUsersQueryResponse>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            result.Add(new GetAllUsersQueryResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                Role = roles.FirstOrDefault() ?? string.Empty
            });
        }

        return result;
    }
}
