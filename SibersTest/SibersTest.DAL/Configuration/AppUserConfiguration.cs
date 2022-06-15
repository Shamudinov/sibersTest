using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SibersTest.DAL.Entities;

namespace SibersTest.DAL.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(250);
            builder.Property(c => c.LastName).HasMaxLength(250);
            builder.Property(c => c.MiddleName).HasMaxLength(250);
            builder.Property(c => c.FirstName).HasMaxLength(250);

            builder
                .HasOne<UTask>(s => s.CreateTask)
                .WithOne(c => c.Author)
                .HasForeignKey<UTask>(c => c.AuthorId);

            builder
                .HasOne<UTask>(s => s.EmployeeTask)
                .WithOne(c => c.TaskPerfomer)
                .HasForeignKey<UTask>(c => c.TaskPerfomerId);
        }
    }
}
