using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities
{
    public partial class Delivery : EntityBase
    {
        public Delivery()
        {
            this.DeliveryProductConnection = new HashSet<DeliveryProductConnection>();
            this.Order = new HashSet<Order>();
        }

        public string Name { get; set; }
    
        public virtual ICollection<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
