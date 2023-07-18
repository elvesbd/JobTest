using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleCatalogAPI.Domain.Models;

namespace VehicleCatalogAPI.Data.Mappings;

public class VehicleMap : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicle");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property("Name")
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("VARCHAR")
               .HasMaxLength(80);

        builder.Property("Brand")
            .IsRequired()
            .HasColumnName("Brand")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property("Model")
               .IsRequired()
               .HasColumnName("Model")
               .HasColumnType("VARCHAR")
               .HasMaxLength(80);

        builder.Property("Image")
            .IsRequired(false)
            .HasColumnName("Image")
            .HasColumnType("VARCHAR")
            .HasMaxLength(2000);
    }
}
