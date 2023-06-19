using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class ActivityMap : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activity");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(f => f.InclusionDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationUser).HasColumnType("int").IsRequired();

            builder.Property(f => f.Description)
                .HasConversion(f => f.ToString(), f => f)
                .IsRequired(false)
                .HasColumnName("Description")
                .HasColumnType("varchar(250))");

            builder.Property(f => f.Deadline)
                .IsRequired()
                .HasColumnName("Deadline")
                .HasColumnType("Datetime");

            builder.Property(f => f.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasColumnType("bit");

            builder.Property(f => f.Type)
                .IsRequired(false)
                .HasColumnName("Type")
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Score)
                .IsRequired()
                .HasColumnName("Score")
                .HasColumnType("int");

            builder.Property(f => f.DailyActivity)
                .IsRequired()
                .HasColumnName("DailyActivity")
                .HasColumnType("bit");
            
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired();
        }
    }
}