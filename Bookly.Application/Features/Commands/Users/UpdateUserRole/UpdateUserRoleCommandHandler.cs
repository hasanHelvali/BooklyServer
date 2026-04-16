using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Bookly.Application.Features.Commands.Users.UpdateUserRole;

public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequest, UpdateUserRoleCommandResponse>
{
    private readonly UserManager<User> _userManager;

    public UpdateUserRoleCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UpdateUserRoleCommandResponse> Handle(UpdateUserRoleCommandRequest request, CancellationToken
cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user is null)
            throw new BusinessException("Kullanıcı bulunamadı.");

        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        await _userManager.AddToRoleAsync(user, request.Role);

        return new UpdateUserRoleCommandResponse("Kullanıcı rolü güncellendi.");
    }
}
