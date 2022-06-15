using SibersTest.DAL;
using SibersTest.DAL.Entities;
using SibersTest.Model.ViewModels;
using SibersTest.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.Service.Services
{
    public class AccountService : Service, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IEnumerable<UserViewModel> GetAllUsers() 
        {
            var users = unitOfWork.Users.GetAll();
            return mapper.Map<IEnumerable<AppUser>, IEnumerable<UserViewModel>>(users);
        }

        public void Edit(UserViewModel userView)
        {
            var user = unitOfWork.Users.GetById(userView.Id);
            user.FirstName = userView.FirstName ?? user.FirstName;
            user.LastName = userView.LastName ?? user.LastName;
            user.MiddleName = userView.MiddleName ?? user.MiddleName;
            user.Email = userView.Email ?? user.Email;
            unitOfWork.Users.Update(user);
            unitOfWork.Commit();
        }
    }
}
