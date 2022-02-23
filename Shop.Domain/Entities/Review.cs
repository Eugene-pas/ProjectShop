using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class Review : EntityBase
    {
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Product Product { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<ReviewComment> ReviewComments { get; set; }

        public virtual ICollection<ReviewLike> ReviewLikes { get; set; }
    }
}
