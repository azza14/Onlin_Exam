using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Exam.Entities;
using Online_Exam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfosController : ControllerBase
    {
        private IUserInfoService _userInfoService;
        public UserInfosController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;

        }
        [HttpPost("Authenticate")]
        public IActionResult Authenticate( [FromBody] AuthenticationModel model)
        {
            var user = _userInfoService.Authenticate(model.UserName, model.Password);
            if (user == null) return BadRequest(new {messae="UserName and password   incorrect"});

            return Ok(user);
        }
        // GET: api/<UserInfoController>
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
