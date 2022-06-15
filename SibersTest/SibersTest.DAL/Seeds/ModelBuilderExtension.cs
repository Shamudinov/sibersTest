using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SibersTest.DAL.Seeds
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            RoleSeed.Seed(modelBuilder);
        }
    }
}
