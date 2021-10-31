using Onlin_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.DTO
{
    public class ChoiceDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }


        //public IList<CorrectAnswer> CorrectAnswers { get; set; }
    }
}
