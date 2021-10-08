using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductSQRS.API.Entity;

namespace ProductSQRS.API.Configuration
{
    public class ProductManagerConfiguration : IEntityTypeConfiguration<ProductManager>
    {
        public void Configure(EntityTypeBuilder<ProductManager> builder)
        {
            builder.ToTable("ProductManagers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.Common);
            
        }
    }
}
