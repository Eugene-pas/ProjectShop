using Shop.Domain.Entities.Base;
using System.Collections.Generic;

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
