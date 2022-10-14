using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class GroupProfileMap : IEntityTypeConfiguration<GroupProfile>
    {
        public void Configure(EntityTypeBuilder<GroupProfile> builder)
        {
            builder.ToTable("GroupProfile");

            builder.HasKey(pf => new
            {
                pf.GroupId,
                pf.ProfileId
            });

            builder.Property(f => f.InclusionDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationDate).HasColumnType("datetime").IsRequired();
            builder.Property(f => f.AlterationUser).HasColumnType("int").IsRequired();

            builder.Property(f => f.ScoreGroup)
                .IsRequired()
                .HasColumnName("ScoreGroup")
                .HasColumnType("int");

/*             builder.HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .IsRequired();

            builder.HasOne(p => p.Profile)
                .WithMany()
                .HasForeignKey(p => p.ProfileId)
                .IsRequired(); */
        }
    }
}