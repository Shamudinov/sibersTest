using AutoMapper;
using SibersTest.DAL;
using SibersTest.Service.AutoMapper;
using SibersTest.Service.Services.Interfaces;

namespace SibersTest.Service.Services
{
    public abstract class Service : IService
    {
        protected IUnitOfWork unitOfWork { get; private set; }
        protected IMapper mapper { get; private set; }
        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            mapper = MapBuilder.Build();
        }
    }
}
