using AutoMapper;
using SibersTest.DAL.Entities;
using SibersTest.Model.Models;
using SibersTest.Model.ViewModels;

namespace SibersTest.Service.AutoMapper
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project, ProjectViewModel>()
                .ForMember(c => c.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.ProjectName, x => x.MapFrom(z => z.ProjectName))
                .ForMember(x => x.ProjectPriority, x => x.MapFrom(z => z.ProjectPriority))
                .ForMember(x => x.StartDate, x => x.MapFrom(z => z.StartDate))
                .ForMember(x => x.CustomerCompany, x => x.MapFrom(z => z.CustomerCompany))
                .ForMember(x => x.EndDate, x => x.MapFrom(z => z.EndDate))
                .ForMember(x => x.ExecutingCompany, x => x.MapFrom(z => z.ExecutingCompany));
            CreateMap<ProjectViewModel, Project>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.ProjectName, x => x.MapFrom(z => z.ProjectName))
                .ForMember(x => x.ProjectPriority, x => x.MapFrom(z => z.ProjectPriority))
                .ForMember(x => x.StartDate, x => x.MapFrom(z => z.StartDate))
                .ForMember(x => x.CustomerCompany, x => x.MapFrom(z => z.CustomerCompany))
                .ForMember(x => x.EndDate, x => x.MapFrom(z => z.EndDate))
                .ForMember(x => x.ExecutingCompany, x => x.MapFrom(z => z.ExecutingCompany));

            CreateMap<AppUser, UserViewModel>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, x => x.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(z => z.LastName))
                .ForMember(x => x.MiddleName, x => x.MapFrom(z => z.MiddleName))
                .ForMember(x => x.Email, x => x.MapFrom(z => z.Email));
            CreateMap<UserViewModel, AppUser>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, x => x.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, x => x.MapFrom(z => z.LastName))
                .ForMember(x => x.MiddleName, x => x.MapFrom(z => z.MiddleName))
                .ForMember(x => x.Email, x => x.MapFrom(z => z.Email))
                .ForMember(x => x.UserName, x => x.MapFrom(z => z.Email));

            CreateMap<UTask, UTaskModel>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.Name, x => x.MapFrom(z => z.Name))
                .ForMember(x => x.Priority, x => x.MapFrom(z => z.Priority))
                .ForMember(x => x.ProjectId, x => x.MapFrom(z => z.ProjectId))
                .ForMember(x => x.TaskPerfomerId, x => x.MapFrom(z => z.TaskPerfomerId))
                .ForMember(x => x.TaskStatus, x => x.MapFrom(z => z.TaskStatus))
                .ForMember(x => x.AuthorId, x => x.MapFrom(z => z.AuthorId))
                .ForMember(x => x.Comments, x => x.MapFrom(z => z.Comments));
            CreateMap<UTaskModel, UTask>()
                .ForMember(x => x.Id, x => x.MapFrom(z => z.Id))
                .ForMember(x => x.Name, x => x.MapFrom(z => z.Name))
                .ForMember(x => x.Priority, x => x.MapFrom(z => z.Priority))
                .ForMember(x => x.ProjectId, x => x.MapFrom(z => z.ProjectId))
                .ForMember(x => x.TaskPerfomerId, x => x.MapFrom(z => z.TaskPerfomerId))
                .ForMember(x => x.TaskStatus, x => x.MapFrom(z => z.TaskStatus))
                .ForMember(x => x.AuthorId, x => x.MapFrom(z => z.AuthorId))
                .ForMember(x => x.Comments, x => x.MapFrom(z => z.Comments));
        }
    }
}
