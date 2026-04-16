using MediatR;

namespace Bookly.Application.Features.Queries.Orders.GetAllOrders;

public class GetAllOrdersQueryRequest : IRequest<List<GetAllOrdersQueryResponse>> { }
