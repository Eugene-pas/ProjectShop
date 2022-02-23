using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class Customer : EntityBase
    {
        public Customer()
        {
            this.Order = new HashSet<Order>();
        }       
        public User User { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
