using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Seeds
{
    public static class RoleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "d8ab412f-b321-4b26-8172-a5d075603dd3", Name = "Employee", NormalizedName = "EMPLOYEE", ConcurrencyStamp = "afd47025-347c-4d3f-a559-3e786a3f6438" },
                new IdentityRole() { Id = "edb57926-50f6-4493-aad2-e1e657d05495", Name = "Supervisor", NormalizedName = "SUPERVISOR", ConcurrencyStamp = "adcbb9d9-4c0f-4d22-9396-fd69e5dea646" },
                new IdentityRole() { Id = "50209db0-e4a4-4d6e-92cb-2777a86e5f37", Name = "ProjectManager", NormalizedName = "PROJECTMANAGER", ConcurrencyStamp = "adcbb9d9-4c0f-4d22-9396-fd69e5dea640" }
            );
        }
    }
}
