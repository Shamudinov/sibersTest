using SibersTest.DAL.DbContext;
using SibersTest.DAL.Repositories;
using SibersTest.DAL.Repositories.Interfaces;
using System;

namespace SibersTest.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext context;
        private ProjectRepository project;
        private AccountRepository user;
        private ProjectUserRepository projectUser;
        private UTaskRepository uTask;

        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
        }

        public IProjectRepository Projects => project = project ?? new ProjectRepository(context);   
        public IAccountRepository Users => user = user ?? new AccountRepository(context);
        public IProjectUserRepository ProjectsUsers => projectUser ?? new ProjectUserRepository(context);
        public IUTaskRepository UTasks => uTask ?? new UTaskRepository(context);

        public void Commit()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
