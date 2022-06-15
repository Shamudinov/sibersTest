using SibersTest.DAL;
using SibersTest.DAL.Entities;
using SibersTest.Model.Models;
using SibersTest.Service.Services.Interfaces;

namespace SibersTest.Service.Services
{
    public class UTaskService : Service, IUTaskService
    {
        public UTaskService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void Create(UTaskModel uTaskModel)
        {
            var uTask = mapper.Map<UTaskModel, UTask>(uTaskModel);
            unitOfWork.UTasks.Add(uTask);
            unitOfWork.Commit();
        }

    }
}
