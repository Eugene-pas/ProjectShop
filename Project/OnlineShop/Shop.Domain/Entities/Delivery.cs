
namespace Shop.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Delivery
    {
        public Delivery()
        {
            this.DeliveryProductConnection = new HashSet<DeliveryProductConnection>();
            this.Order = new HashSet<Order>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
