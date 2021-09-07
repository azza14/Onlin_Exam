using Microsoft.AspNetCore.Mvc;
using Onlin_Exam.Models;
using Onlin_Exam.Repositories;
using Onlin_Exam.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//Add-Migration InitialCreate -Context OnlineDbContext -OutputDir Data\SqlServerMigrations

namespace Onlin_Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IGenericRepository<User> _repoUser;

        public AccountsController(IGenericRepository<User> repository)
        {
            _repoUser = repository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _repoUser.GetAll();
            return Ok(userList);
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterViewModel model)
        {
            try
            {
                var newUser = new User()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    Phone = model.Phone,
                    UserType = model.UserType
                };
                _repoUser.Insert(newUser);
                _repoUser.Save();
                return Ok(new { message = "User Register successfully" });
                //   return new Response {Status = "Success", Message = "Record SuccessFully Saved." };
            }
            catch
            {
                return BadRequest();
                //return new Response
                //{
                //    Status = "Failed",
                //    Message = "Record Failed Saved."
                //};
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _repoUser
                .GetByCondition(u => u.Email == model.Email && u.Password == model.Password)
                .FirstOrDefault();
            if (user != null)
            {
                return Ok(new { message = "User login successfully" });
            }

            else
            {
               return BadRequest(new { message = "Username or password is incorrect." });
            }
        }

        [HttpPost]       
        [Route("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var user = _repoUser.GetByCondition(u => u.Password == model.CurrentPassword).FirstOrDefault();
            if (user != null)
            {
                user.Password = model.NewPassword;
                _repoUser.Update(user);
                _repoUser.Save();
            }
            
            return Ok( new { message="update password succefull"});
        }

        [HttpPost]
        [Route("RestPassword")]
        public IActionResult RestPassword(string email)
        {
            var user = _repoUser.GetByCondition(u => u.Email == email).FirstOrDefault();
            
            if (user != null)
            {

               // user.Password = model.NewPassword;
                _repoUser.Update(user);
                _repoUser.Save();
                return Ok();
            }
            return Ok();
        }
    }
}
            
