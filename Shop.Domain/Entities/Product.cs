using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public partial class Product : EntityBase
    {
        public Product()
        {
            this.DeliveryProductConnection = new HashSet<DeliveryProductConnection>();
            this.OrderProductConnection = new HashSet<OrderProductConnection>();
            this.ProductImage = new HashSet<ProductImage>();
        } 
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int? OnStorageCount { get; set; }
    
        public virtual Category Category { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual ICollection<DeliveryProductConnection> DeliveryProductConnection { get; set; }

        public virtual ICollection<OrderProductConnection> OrderProductConnection { get; set; }

        public virtual ICollection<ProductImage> ProductImage { get; set; }

        public virtual ICollection<Review> Review { get; set; }
    }
}
