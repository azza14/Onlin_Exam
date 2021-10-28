using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Degree { get; set; }

        public int ExamId { get; set; }
        public Exam  Exam{ get; set; }

        public List<Choice> Choices { get; set; }
        public List<CorrectAnswer> ListCorrectAnswers { get; set; }

        
    }
}
