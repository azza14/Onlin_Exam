using Online_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.DTO
{
    public class AuthUser
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
