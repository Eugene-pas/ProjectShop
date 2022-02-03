using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public partial class DeliveryProductConnection : EntityBase
    {       
        public virtual Delivery Delivery { get; set; }
        public virtual Product Product { get; set; }
    }
}
