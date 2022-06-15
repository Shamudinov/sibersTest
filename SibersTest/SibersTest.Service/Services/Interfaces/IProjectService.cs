using SibersTest.Model.Models;
using SibersTest.Model.ViewModels;
using System.Collections.Generic;

namespace SibersTest.Service.Services.Interfaces
{
    public interface IProjectService
    {
        void Create(ProjectViewModel project);
        IEnumerable<ProjectViewModel> GetAllProjects();
        void Edit(ProjectViewModel project);
        void Delete(ProjectViewModel projectView);
        void AddEmployeeToProject(UserProjectModel model);
        void RemoveEmployeeFromProject(UserProjectModel model);
        IEnumerable<ProjectViewModel> GetEmployeeProjects(string userId);
        //IEnumerable<ProjectViewModel> GetEmployeeProjects(string userId);
    }
}
