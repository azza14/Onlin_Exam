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
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Online_Exam.CustomAuth;


namespace Online_Exam.Controllers
{
    //[Authorization.CustmeAuthorize]
    [Route("api/[controller]")]
    [ApiController]
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

        [CustomAuthorize(Role.Admin)]
        [HttpGet("GetUsers")]
        public IActionResult GetAll()
        {
            var userList = _repoUser.GetAll();
            return Ok(userList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin)
                return Unauthorized(new {  message = "Unauthorized" });

            var user = _repoUser.GetById(id);
            if (user == null) 
                throw new KeyNotFoundException("User not found");

            return Ok(user);
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

                    return Ok(new AuthUser
                    {
                        User = user,
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
             
            return  Ok( new AuthUser { User= user, Token = token});
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
       
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDTO model)
        {
            var user = _repoUser.GetById(id);
            if (user == null)
                return NotFound();
            var editUser= _mapper.Map(model, user);
            _repoUser.Update(editUser);
            _repoUser.Save();
            return Ok(new { message = " update User success" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Exam = _repoUser.GetById(id);
            if (Exam == null)
                return NotFound();
            _repoUser.Delete(id);
            _repoUser.Save();
            return Ok(new { message = " delete User success" });
        }


    }
}
