using Onlin_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Services
{
    public interface IUserInfoService
    {
        UserInfo Authenticate(string userName, string password);
    }
}
