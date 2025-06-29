using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductFlow.Core.Domain.Entity;

namespace ProductFlow.Core.Infra.Dao.EntityConfig
{
    public class UserEntityConfig : BaseEntityConfig<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("tb_user");

            builder.HasIndex(prop => prop.Email)
                .IsUnique();

            builder.Property(props => props.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(props => props.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
