using AutoMapper;
using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Bookly.Application.Features.Commands.Auth.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    public RegisterCommandHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async  Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        User user = _mapper.Map<User>(request);
        IdentityResult result= await _userManager.CreateAsync(user,request.Password);
        if (!result.Succeeded)
            throw new BusinessException(string.Join(", ", result.Errors.Select(e=>e.Description)));

        return new RegisterCommandResponse("Kayıt Başarılı.");
    }
}
