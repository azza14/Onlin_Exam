using Onlin_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.DTO
{
    public class CorrectAnswerDTO
    {
        public Question Question { get; set; }
        public List<Choice> Choices { get; set; }
        public List<CorrectAnswer> CorrectAnswers { get; set; }
    }
}
