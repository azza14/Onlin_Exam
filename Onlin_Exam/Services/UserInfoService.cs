using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Online_Exam.Helpers;
using Online_Exam.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Online_Exam.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly AppSettings _appSetting;
        private List<UserInfo> _users = new List<UserInfo>()
        {
            new UserInfo
                {
                    UserInfoId=Guid.NewGuid(),
                    FullName="Ali Omar",
                    UserName="Ali",
                    Password="123",
                }
        };
        public UserInfoService(IOptions<AppSettings> appSettings)
        {
            _appSetting = appSettings.Value;
        }
        public UserInfo Authenticate(string userName, string password)
        {
            var user = _users.Where(u =>
                           u.UserName == userName && u.Password == password).SingleOrDefault();
            if (user == null) return null;

            var tokenHandeler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserInfoId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials=  new SigningCredentials(
                                          new SymmetricSecurityKey(key),
                                          SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandeler.CreateToken(tokenDescriptor);
            user.Token = tokenHandeler.WriteToken(token);


            return user;
        }
         public IEnumerable<UserInfo> GetAll()
        {
            return _users;
        } 


    }
}
