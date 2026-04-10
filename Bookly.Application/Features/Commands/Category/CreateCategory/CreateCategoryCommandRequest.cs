using MediatR;

namespace Bookly.Application.Features.Commands.Category.CreateCategory;
public record CreateCategoryCommandRequest(string Name) : IRequest<CreateCategoryCommandResponse>;
