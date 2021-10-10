using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.DTO
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Phone { get; set; }
    }
}
