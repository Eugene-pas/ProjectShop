using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public partial class ProductImage : EntityBase
    {       
        public string Image { get; set; }
        public int? SortOrder { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
