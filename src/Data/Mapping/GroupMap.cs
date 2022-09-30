using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(f => f.InclusionDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationUser).HasColumnType("int").IsRequired();

            builder.Property(f => f.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar(250)");
        }
    }
}