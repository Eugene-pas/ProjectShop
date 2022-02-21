using Shop.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain.Entities
{
    public class Basket
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        public decimal? TotalSum { get; set; }

        public virtual Customer Customer { get; set; }
        public ICollection<BasketItem> Items { get; set; }
    }
}
