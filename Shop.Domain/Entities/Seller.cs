using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public partial class Seller : EntityBase
    {
        public Seller()
        {
            this.Product = new HashSet<Product>();
        }       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }  
        public virtual ICollection<Product> Product { get; set; }
    }
}
