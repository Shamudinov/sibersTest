using SibersTest.DAL.DbContext;
using SibersTest.DAL.Entities;
using SibersTest.DAL.Repositories.Interfaces;

namespace SibersTest.DAL.Repositories
{
    public class UTaskRepository : RepositoryBase<UTask>, IUTaskRepository
    {
        public UTaskRepository(DatabaseContext context) : base(context) { }
    }
}
