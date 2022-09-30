using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class RankMap : IEntityTypeConfiguration<Rank>
    {
        public void Configure(EntityTypeBuilder<Rank> builder)
        {
            builder.ToTable("Rank");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(f => f.InclusionDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationUser).HasColumnType("int").IsRequired();

            builder.Property(f => f.Score)
                .IsRequired()
                .HasColumnName("Score")
                .HasColumnType("int");

            builder.HasOne(p => p.Profile)
                .WithMany()
                .HasForeignKey(p => p.ProfileId)
                .IsRequired();

            builder.HasOne(p => p.RankType)
                .WithMany()
                .HasForeignKey(p => p.RankTypeId)
                .IsRequired();
        }
    }
}