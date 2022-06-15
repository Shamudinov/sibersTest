using SibersTest.DAL.Entities;
using SibersTest.DAL.Repositories.Interfaces;
using SibersTest.DAL;
using SibersTest.Model.ViewModels;
using SibersTest.Service.Services.Interfaces;
using System.Collections.Generic;
using SibersTest.Model.Models;
using System.Linq;

namespace SibersTest.Service.Services
{
    public class ProjectService : Service, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
        }

        public void Create(ProjectViewModel projectView)
        {
            var project = new Project()
            {
                ProjectName = projectView.ProjectName,
                ProjectPriority = projectView.ProjectPriority,
                CustomerCompany = projectView.CustomerCompany,
                StartDate = projectView.StartDate,
                EndDate = projectView.EndDate,
                ExecutingCompany = projectView.ExecutingCompany
            };
            unitOfWork.Projects.Add(project);
            unitOfWork.Commit();
        }

        public IEnumerable<ProjectViewModel> GetAllProjects()
        {
            var projects = unitOfWork.Projects.GetAll();
            return mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);
        }

        public void Edit(ProjectViewModel projectView)
        {
            var project = unitOfWork.Projects.GetById(projectView.Id);

            project.ProjectName = projectView.ProjectName ?? project.ProjectName;
            project.CustomerCompany = projectView.CustomerCompany ?? project.CustomerCompany;
            project.ExecutingCompany = projectView.ExecutingCompany ?? project.ExecutingCompany;
           
            
            // project.ProjectPriority = projectView.ProjectPriority ?? project.ProjectPriority;
           // project.StartDate = projectView.StartDate ?? project.StartDate;
           // project.EndDate = projectView.EndDate ?? project.EndDate;

            unitOfWork.Projects.Update(project);
            unitOfWork.Commit();
        }

        public void Delete(ProjectViewModel projectView)
        {
            var project = mapper.Map<ProjectViewModel, Project>(projectView);
            unitOfWork.Projects.Delete(project);
            unitOfWork.Commit();
        }

        public void AddEmployeeToProject(UserProjectModel model)
        {
            var userProject = new ProjectUser();
            
            var project = unitOfWork.Projects.GetById(model.ProjectId);
            var user = unitOfWork.Users.GetById(model.UserId);
            
            userProject.ProjectId = model.ProjectId;
            userProject.UserId = model.UserId;
            userProject.User = user;
            userProject.Project = project;

            unitOfWork.ProjectsUsers.Add(userProject);
            unitOfWork.Commit();
        }

        public void RemoveEmployeeFromProject(UserProjectModel model)
        {
            var userTeam = unitOfWork.ProjectsUsers.GetAll().FirstOrDefault(x => x.ProjectId == model.ProjectId && x.UserId == model.UserId);
            unitOfWork.ProjectsUsers.Delete(userTeam);
            unitOfWork.Commit();
        }

        public IEnumerable<ProjectViewModel> GetEmployeeProjects(string userId)
        {
            var projects = unitOfWork.ProjectsUsers.GetAll().Where(x => x.UserId == userId).Select(x => x.Project);
            return mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);
        }

    }
}
