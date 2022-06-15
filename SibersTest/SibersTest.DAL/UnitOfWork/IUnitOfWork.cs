using SibersTest.DAL.Repositories.Interfaces;
using System;

namespace SibersTest.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository Projects { get;}
        IAccountRepository Users { get;}
        IProjectUserRepository ProjectsUsers { get; }
        IUTaskRepository UTasks { get; }
        void Commit();
    }
}
