using SibersTest.DAL.Entities;
using SibersTest.Model.ViewModels;
using System.Collections.Generic;

namespace SibersTest.Service.Services.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        void Edit(UserViewModel user);
    }
}
