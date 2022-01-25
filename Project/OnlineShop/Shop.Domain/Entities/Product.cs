namespace Shop.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        public Product()
        {
            this.DeliveryProductConnection = new HashSet<DeliveryProductConnection>();
            this.OrderProductConnection = new HashSet<OrderProductConnection>();
            this.ProductImage = new HashSet<ProductImage>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> Rating { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        public virtual ICollection<OrderProductConnection> OrderProductConnection { get; set; }
        public virtual Sellers Sellers { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
    }
}
