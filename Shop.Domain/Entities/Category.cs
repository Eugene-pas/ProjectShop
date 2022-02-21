using Shop.Domain.Entities.Base;
using System.Collections.Generic;

namespace Shop.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            this.Product = new HashSet<Product>();
        }
        public string Name { get; set; }

        public ICollection<CategoryConnection> Child { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
