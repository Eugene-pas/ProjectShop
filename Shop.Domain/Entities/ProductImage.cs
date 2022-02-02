namespace Shop.Domain.Entities
{
    using Shop.Domain.Entities.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ProductImage : EntityBase
    {       
        public byte[] Image { get; set; }
        public Nullable<int> Sort_order { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
