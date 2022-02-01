
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Notes.Persistence.EntityTypeConfigurations
{
    // ���� ���� ������ IEntityTypeConfiguration
    // ���� �������� �������� ������������ ����
    // ������� �� ������� ���� � �� � ����� OnModelCreating
    // ������ DbContext
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        // ����� ��������� ������������
        // ������ ����� �� ���� ������� ��������
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => customer.Id);
            builder.HasIndex(customer => customer.Id).IsUnique();
            builder.Property(customer => customer.Name).HasMaxLength(250);


            //builder.HasOne(x => x.UserId).withone()
        }
    }
}