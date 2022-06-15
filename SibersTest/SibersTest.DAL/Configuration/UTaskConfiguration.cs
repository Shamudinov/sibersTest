using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SibersTest.DAL.Entities;

namespace SibersTest.DAL.Configuration
{
    public class UTaskConfiguration : IEntityTypeConfiguration<UTask>
    {

        public void Configure(EntityTypeBuilder<UTask> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(250);
            builder.Property(c => c.Comments).HasMaxLength(250);

            builder.HasOne<Project>(s => s.TaskProject)
                .WithMany(g => g.UTasks)
                .HasForeignKey(s => s.ProjectId);
        }
    }
}
