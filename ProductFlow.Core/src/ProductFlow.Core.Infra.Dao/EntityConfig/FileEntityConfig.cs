using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductFlow.Core.Domain.Entity;

namespace ProductFlow.Core.Infra.Dao.EntityConfig
{
    public class FileEntityConfig : BaseEntityConfig<FileEntity>
    {
        public override void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("tb_file");

            builder.Property(prop => prop.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(180)")
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(prop => prop.SizeByte)
                .HasColumnName("size_byte")
                .IsRequired();

            builder.Property(prop => prop.TotalRows)
                .HasColumnName("total_row")
                .IsRequired();

            builder.Property(prop => prop.Path)
                .HasColumnName("path")
                .HasColumnType("varchar(280)")
                .HasMaxLength(280)
                .IsRequired();

            builder.Property(prop => prop.Extension)
                .HasColumnName("extension")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(prop => prop.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(prop => prop.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(prop => prop.User)
                .WithMany(prop => prop.Files)
                .HasForeignKey(prop => prop.UserId);
        }
    }
}
