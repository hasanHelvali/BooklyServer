using Bookly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookly.Persistence.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ID);
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Author).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(p => p.Stock).IsRequired();
        builder.Property(p => p.ImageUrl).HasMaxLength(500);
        builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        /*
         Bir kategori silinmek istendiğinde, o kategoriye bağlı ürünler varsa silme işlemini engeller ve hata fırlatır.

Alternatifler:
- Cascade — kategori silinince bağlı ürünler de silinir
- SetNull — CategoryId null'a çekilir (nullable olması lazım)
- Restrict — engeller, hata fırlatır

Kitap uygulaması için Restrict mantıklı — yanlışlıkla kategori silinip onlarca ürün kaybolmasın.
         */
    }
}
