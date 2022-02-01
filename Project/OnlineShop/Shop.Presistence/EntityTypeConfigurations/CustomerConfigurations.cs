
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Notes.Persistence.EntityTypeConfigurations
{
    // клас який реалізує IEntityTypeConfiguration
    // який дозволяє розділяти конфігурацію типу
    // сутності на окремий клас а не в методі OnModelCreating
    // нашого DbContext
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        // задаєм параметри конфігурації
        // вказуєм ключі та інші правила валідації
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => customer.Id);
            builder.HasIndex(customer => customer.Id).IsUnique();
            builder.Property(customer => customer.Name).HasMaxLength(250);


            //builder.HasOne(x => x.UserId).withone()
        }
    }
}