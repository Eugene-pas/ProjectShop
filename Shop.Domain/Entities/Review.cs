using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class Review : EntityBase
    {
        public virtual Product Product { get; set; }

        public string CustomerName { get; set; }

        public int Rating { get; set; }

        public string Comments { get; set; }

        public DateTime Created { get; set; }
    }
}
