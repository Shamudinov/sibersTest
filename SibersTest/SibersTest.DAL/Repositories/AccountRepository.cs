using SibersTest.DAL.DbContext;
using SibersTest.DAL.Entities;
using SibersTest.DAL.Repositories.Interfaces;

namespace SibersTest.DAL.Repositories
{
    public class AccountRepository : RepositoryBase<AppUser>, IAccountRepository
    {
        public AccountRepository(DatabaseContext context) : base(context) { }
    }
}
