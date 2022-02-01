
namespace Shop.Domain.Entities
{
    using Shop.Domain.Entities.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderProductConnection : EntityBase
    {      
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
