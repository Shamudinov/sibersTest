using Microsoft.EntityFrameworkCore;
using SibersTest.DAL.DbContext;
using SibersTest.DAL.Entities;
using SibersTest.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SibersTest.DAL.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {

        public ProjectRepository(DatabaseContext context ) : base(context) { }

        

    }
}
