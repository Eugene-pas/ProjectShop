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
        public string StoreName { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }  
        public User User { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
