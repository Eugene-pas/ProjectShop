using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public partial class Order : EntityBase
    {
        public Order()
        {
            this.OrderProductConnection = new HashSet<OrderProductConnection>();
        }        
        public DateTime? Date { get; set; }
        public string Adress { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Delivery Delivery { get; set; }
        public virtual ICollection<OrderProductConnection> OrderProductConnection { get; set; }
    }
}
