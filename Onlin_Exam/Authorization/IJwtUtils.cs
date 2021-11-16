using Online_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Authorization
{
    public interface IJwtUtils
    {
        string CreateToken(User user);
        public int? ValidateToken(string token);

    }
}
