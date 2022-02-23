using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface IDataBaseContext
    {
        DbSet<Basket> Basket { get; set; }
        DbSet<BasketItem> BasketItem { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<CategoryConnection> CategoryConnection { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Delivery> Delivery { get; set; }
        DbSet<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderProductConnection> OrderProductConnection { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductImage> ProductImage { get; set; }
        DbSet<Seller> Seller { get; set; }
        DbSet<Review> Review { get; set; }
        DbSet<ReviewComment> ReviewComment { get; set; }
        DbSet<ReviewLike> ReviewLike { get; set; }
        DbSet<User> User { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}