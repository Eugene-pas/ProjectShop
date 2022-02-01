using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public interface IDataBaseContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Delivery> Delivery { get; set; }
        DbSet<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderProductConnection> OrderProductConnection { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<ProductImage> ProductImage { get; set; }
        DbSet<Sellers> Sellers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}