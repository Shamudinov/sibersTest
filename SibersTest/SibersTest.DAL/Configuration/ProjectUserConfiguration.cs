using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SibersTest.DAL.Entities;

namespace SibersTest.DAL.Configuration
{
    public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
    {
        public void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            builder.HasKey(c => new { c.UserId, c.ProjectId });
            builder.HasOne<AppUser>(c => c.User)
                   .WithMany(c => c.Projects)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne<Project>(c => c.Project)
                   .WithMany(c => c.Employees)
                   .HasForeignKey(c => c.ProjectId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
