using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Exam.Authorization;
using Online_Exam.DTO;
using Online_Exam.Entities;
using Online_Exam.Helpers;
using Online_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Exam.Controllers
{
   // [Authorization.Authorize]
    [Route("api/[controller]")]
  //  [ApiController]
    public class UsersController : ControllerBase
    {
        private IJwtUtils _userInfoService;
        private IGenericRepository<User> _repoUser;
        private readonly IMapper _mapper;

        public UsersController(
                    IGenericRepository<User> repository,
                    IJwtUtils userInfoService,
                    IMapper mapper)
        {
            _userInfoService = userInfoService;
            _mapper = mapper;
            _repoUser = repository;
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = ("SuperAdmin"))]
        [HttpGet("GetUsers")]
        public IActionResult GetAll()
        {
            var userList = _repoUser.GetAll();
            return Ok(userList);
        }
        [HttpGet("{id}")]
        public User GetById(int id)
        {
            var user = _repoUser.GetById(id);
            if (user == null) 
                throw new KeyNotFoundException("User not found");
            return user;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO model)
        {
            try
            {
                bool usernameAlreadyExists = _repoUser.IsExists(n => n.UserName == model.Username);
                if (ModelState.IsValid && !usernameAlreadyExists)
                {
                    var newUser = _mapper.Map<User>(model);
                    var user = _repoUser.InsertWithReturn(newUser);
                    _repoUser.Save();
                    var token = _userInfoService.CreateToken(user);

                    return Ok(new Response
                    {
                        Message = "User Register successfully",
                        Status = "succes",
                        Token = token
                    });
                }
                else
                {
                    return Ok(new Response
                    {
                        Message = "UserName already exist   ",
                        Status = "fail"
                    });
                }
            }
            catch
            {
                return BadRequest();

            }
        }
        [Authorization.AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO model)
        {
            var user = _repoUser.GetOne(
                                 u => u.UserName == model.Username &&
                                 u.Password == model.Password);
          
            if (user == null) 
                throw new AppException("Username or password is incorrect");
             var token=   _userInfoService.CreateToken(user);
             
            return  Ok(new AuthUser
            {
                User= user,
                Token = token
            });
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDTO model)
        {
            var user = _repoUser.GetByCondition( u => u.Password == model.CurrentPassword)
                                .FirstOrDefault();
            if (user != null)
            {
                user.Password = model.NewPassword;
                _repoUser.Update(user);
                _repoUser.Save();
            }

            return Ok(new { message = "update password succefull" });
        }

        [HttpPost]
        [Route("RestPassword")]
        public IActionResult RestPassword(string email)
        {
            var user = _repoUser.GetByCondition(u => u.Email == email)
                                .FirstOrDefault();

            if (user != null)
            {
                _repoUser.Update(user);
                _repoUser.Save();
                return Ok();
            }
            return Ok();
        }


        
    }
}
