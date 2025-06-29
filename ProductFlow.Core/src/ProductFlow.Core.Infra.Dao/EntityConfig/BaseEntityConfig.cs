using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductFlow.Core.Domain.Entity;

namespace ProductFlow.Core.Infra.Dao.EntityConfig
{
    public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Id)
                .HasColumnName("id");

            builder.Property(prop => prop.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}
