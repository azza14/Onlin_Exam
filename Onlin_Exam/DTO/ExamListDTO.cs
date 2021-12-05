using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.DTO
{
    public class ExamListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuestionsCount { get; set; }
        public int Score { get; set; }
        public string CategoryName { get; set; }
    }
}
