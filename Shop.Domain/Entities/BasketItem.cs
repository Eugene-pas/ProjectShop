using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class BasketItem : EntityBase
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public Basket Basket { get; set; }
    }
}