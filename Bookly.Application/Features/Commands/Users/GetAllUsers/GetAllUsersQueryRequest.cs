using MediatR;

namespace Bookly.Application.Features.Commands.Users.GetAllUsers;

public class GetAllUsersQueryRequest : IRequest<List<GetAllUsersQueryResponse>> { }
