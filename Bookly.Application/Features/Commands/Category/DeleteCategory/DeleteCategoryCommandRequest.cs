using MediatR;

namespace Bookly.Application.Features.Commands.Category.DeleteCategory;

public record DeleteCategoryCommandRequest(Guid Id):IRequest<DeleteCategoryCommandResponse>;
