namespace Shop.Domain.Entities
{
    using Microsoft.EntityFrameworkCore;

    public partial class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<DeliveryProductConnection> DeliveryProductConnection { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProductConnection> OrderProductConnection { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
    }
}
