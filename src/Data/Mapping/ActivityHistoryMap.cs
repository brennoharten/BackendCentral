using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class ActivityHistoryMap : IEntityTypeConfiguration<ActivityHistory>
    {
        public void Configure(EntityTypeBuilder<ActivityHistory> builder)
        {
            builder.ToTable("ActivityHistory");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(f => f.InclusionDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationUser).HasColumnType("int").IsRequired();

            builder.Property(f => f.Count)
                .IsRequired()
                .HasColumnName("Count")
                .HasColumnType("int");

            builder.Property(f => f.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("Datetime");

            builder.HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .IsRequired();

            builder.HasOne(p => p.Activity)
                .WithMany()
                .HasForeignKey(p => p.ActivityId)
                .IsRequired();
        }
    }
}