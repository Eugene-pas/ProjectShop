
namespace Shop.Domain.Entities
{
    using Shop.Domain.Entities.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CategoryConnection : EntityBase
    {        
        public virtual Category Category { get; set; }
        public virtual Category Parent { get; set; }
    }
}
