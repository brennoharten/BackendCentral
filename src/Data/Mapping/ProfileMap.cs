using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(f => f.InclusionDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationUser).HasColumnType("int").IsRequired();

            builder.Property(f => f.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Birthdate)
                .IsRequired()
                .HasColumnName("Birthdate")
                .HasColumnType("datetime");

            builder.Property(f => f.Phone)
                .IsRequired()
                .HasColumnName("Phone")
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Genre)
                .IsRequired()
                .HasColumnName("Genre")
                .HasColumnType("varchar(50)");

        }
    }
}