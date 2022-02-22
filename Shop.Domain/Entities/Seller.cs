using Shop.Domain.Entities.Base;
using System.Collections.Generic;

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
