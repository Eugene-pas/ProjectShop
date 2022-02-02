using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities
{
    public partial class OrderProductConnection : EntityBase
    {      
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
