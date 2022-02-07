using AutoMapper;
using MediatR;
using Shop.Application.Common.Mappings;
using Shop.Domain.Entities;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Queries.GetDeliveryProductConnectionsList
{
    public class GetDeliveryProductConnectionsListQuery : IRequest<DeliveryProductConnectionsListVm>
    {
        public long Id { get; set; }
    }
}
