using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;

namespace Shop.Application.Interfaces
{
    public interface IDataBaseContext
    {
        DbSet<CategoryConnection> CategoryConnection { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Delivery> Delivery { get; set; }
        DbSet<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderProductConnection> OrderProductConnection { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductImage> ProductImage { get; set; }
        DbSet<Seller> Seller { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}