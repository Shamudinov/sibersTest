using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SibersTest.DAL.Entities;
using SibersTest.Model.Models;
using SibersTest.Model.ViewModels;
using SibersTest.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SibersTest.Web.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<AppUser> userManager, IAccountService accountService, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.accountService = accountService;
            this.configuration = configuration;
        }
        /// <summary>
        /// Login account
        /// </summary>
        [HttpGet("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                JwtSecurityToken token;

                token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(10),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    ) ;

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    userRoles = userRoles,
                    userId = user.Id
                });
            }
            return Unauthorized();
        }

        [HttpPost("SingUp")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

        public IActionResult SingUp(RegisterModel model)
        {
            var user_ = userManager.FindByNameAsync(model.UserName).Result;

            if (user_ != null)
            {
                return BadRequest(StatusCodes.Status406NotAcceptable);
            }

            AppUser user = new AppUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            try
            {
                var result = userManager.CreateAsync(user, model.Password).Result;
                var role = userManager.AddToRoleAsync(user, model.Role).Result;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            return Ok();
        }
        /// <summary>
        /// Вывод всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = accountService.GetAllUsers();
            return Ok(users);
        }

        /// <summary>
        /// Редактирование пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Edit")]
        public IActionResult Edit(UserViewModel user)
        {
            
            accountService.Edit(user);
            return Ok();
        }



    }
}
