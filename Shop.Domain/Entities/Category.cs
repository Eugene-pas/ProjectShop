using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities
{
    public partial class Category : EntityBase
    {
        public Category()
        {
            //this.ParentCategory = new HashSet<Category>();
            this.Product = new HashSet<Product>();
        }
        public string Name { get; set; }
        public long parentId { get; set; }

       // public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Product>? Product { get; set; }
    }
}
