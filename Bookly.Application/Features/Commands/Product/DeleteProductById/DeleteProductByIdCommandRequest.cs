using MediatR;

namespace Bookly.Application.Features.Commands.Product.DeleteProductById;
public record DeleteProductByIdCommandRequest(Guid Id):IRequest<DeleteProductByIdCommandResponse>;
