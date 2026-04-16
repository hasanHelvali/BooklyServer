using MediatR;

namespace Bookly.Application.Features.Queries.Orders.GetMyOrders;
public class GetMyOrdersQueryRequest : IRequest<List<GetMyOrdersQueryResponse>> { }
