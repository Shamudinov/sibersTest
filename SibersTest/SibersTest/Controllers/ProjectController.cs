using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SibersTest.Model.Models;
using SibersTest.Model.ViewModels;
using SibersTest.Service.Services.Interfaces;
using System;
using System.Net;

namespace SibersTest.Web.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        /// <summary>
        /// Добавление нового проект
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult Create(ProjectViewModel project)
        {
            try
            {
                projectService.Create(project);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Вывод всех проектов
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProjects")]
        public IActionResult GetAllProjects()
        {
            var projects = projectService.GetAllProjects();
            return Ok(projects);
        }
        /// <summary>
        /// Редактор проекта
        /// </summary>
        /// <returns></returns>
        [HttpPost("EditProject")]
        public IActionResult EditProject(ProjectViewModel project)
        {
            projectService.Edit(project);
            return Ok();
        }
        /// <summary>
        /// Удаление проекта
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost("DeleteProject")]
        public IActionResult DeleteProject(ProjectViewModel project)
        {
            projectService.Delete(project);
            return Ok();
        }

        /// <summary>
        /// Добавление сотрудника в команду
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("AddEmployeeToProject")]
        public IActionResult AddEmployeeToProject(UserProjectModel model)
        {
            try
            {
                projectService.AddEmployeeToProject(model);
            }
            catch(Exception e)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }



        /// <summary>
        /// Удаление сотрудника с проекта
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("RemoveEmployeeFromProject")]
        public IActionResult RemoveEmployeeFromProject(UserProjectModel model)
        {
            try
            {
                projectService.RemoveEmployeeFromProject(model);
            }
            catch (Exception e)
            {
                return BadRequest(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        /// <summary>
        /// Получение задач сотрудника 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetEmployeeProjects")]
        public IActionResult GetEmployeeProjects(string userId)
        {
            var projects = projectService.GetEmployeeProjects(userId);
            return Ok(projects);
        }
    }
}
