using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property("Name")
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("VARCHAR")
               .HasMaxLength(80);

        builder.Property("Email")
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.Property("CellPhone")
               .IsRequired()
               .HasColumnName("CellPhone")
               .HasColumnType("VARCHAR")
               .HasMaxLength(80);

        builder.Property("PasswordHash")
               .IsRequired()
               .HasColumnName("PasswordHash")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(150);
    }
}
