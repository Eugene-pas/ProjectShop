
namespace Shop.Domain.Entities
{
    using Shop.Domain.Entities.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Category : EntityBase
    {
        public Category()
        {
            this.CategoryConnection = new HashSet<CategoryConnection>();
            this.CategoryConnection1 = new HashSet<CategoryConnection>();
            this.Product = new HashSet<Product>();
        }
        public string Name { get; set; }
    
        public virtual ICollection<CategoryConnection> CategoryConnection { get; set; }
        public virtual ICollection<CategoryConnection> CategoryConnection1 { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
