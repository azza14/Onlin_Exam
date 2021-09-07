using Onlin_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Entities
{
    public class TestSession
    {
        public int Id { get; set; }
       
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User Student { get; set; }

        public int TestId { get; set; }
        public Test Test{ get; set; }



    }
}
