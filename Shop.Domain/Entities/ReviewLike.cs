using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class ReviewLike : EntityBase
    {
        public bool IsLike { get; set; }

        public virtual Review Review { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
