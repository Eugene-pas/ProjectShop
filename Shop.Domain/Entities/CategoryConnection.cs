using Shop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class CategoryConnection : EntityBase
    {
        public long ParentId { get; set; }

        public virtual Category Category { get; set; }
    }
}
