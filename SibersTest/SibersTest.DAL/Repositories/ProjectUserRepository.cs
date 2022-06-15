using Microsoft.EntityFrameworkCore;
using SibersTest.DAL.DbContext;
using SibersTest.DAL.Entities;
using SibersTest.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.DAL.Repositories
{
    public class ProjectUserRepository : RepositoryBase<ProjectUser>, IProjectUserRepository
    {
        public ProjectUserRepository(DatabaseContext context) : base(context) { }
        public override IEnumerable<ProjectUser> GetAll()
        {
            var x = dataContext.ProjectsUsers.Include(x => x.Project).ToList();
            return x;
        }
    }
}
