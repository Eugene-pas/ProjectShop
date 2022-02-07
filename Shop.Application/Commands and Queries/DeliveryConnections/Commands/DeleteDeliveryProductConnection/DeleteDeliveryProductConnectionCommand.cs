﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands_and_Queries.DeliveryConnections.Commands.DeleteDeliveryProductConnection
{
    public class DeleteDeliveryProductConnectionCommand : IRequest
    {
        public long Id { get; set; }
        public long DeliveryId { get; set; }
        public long ProductId { get; set; }
    }
}