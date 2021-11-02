using Online_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Services
{
    public interface IUserInfoService
    {
        UserInfo Authenticate(string userName, string password);
    }
}
