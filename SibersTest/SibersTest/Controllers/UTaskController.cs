using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibersTest.Model.Models;
using SibersTest.Service.Services.Interfaces;

namespace SibersTest.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UTaskController : ControllerBase
    {
        private readonly IUTaskService uTaskService;
        public UTaskController(IUTaskService uTaskService)
        {
            this.uTaskService = uTaskService;
        }
        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult Create(UTaskModel project)
        {
            uTaskService.Create(project);
            return Ok();
        }
    }
}
