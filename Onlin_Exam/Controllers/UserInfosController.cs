using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onlin_Exam.Models;
using Onlin_Exam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Onlin_Exam.Controllers
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

        // GET api/<UserInfoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserInfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserInfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserInfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
