using Online_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Entities
{
    public class ExamSession
    {
        public int Id { get; set; }
       
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User Student { get; set; }

        public int ExamId { get; set; }
        public Exam Exam{ get; set; }



    }
}
