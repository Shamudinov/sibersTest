using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SibersTest.DAL.Entities;

namespace SibersTest.DAL.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(c => c.ProjectName).HasMaxLength(250);
            builder.Property(c => c.CustomerCompany).HasMaxLength(250);
            builder.Property(c => c.ExecutingCompany).HasMaxLength(250);
        }
    }
}
