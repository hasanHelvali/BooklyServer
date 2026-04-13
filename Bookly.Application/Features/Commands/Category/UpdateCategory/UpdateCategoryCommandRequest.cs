using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookly.Application.Features.Commands.Category.UpdateCategory
{
    public record UpdateCategoryCommandRequest(Guid Id, string Name) : IRequest<UpdateCategoryCommandResponse>;
}
