using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Entities
{
    public class CorrectAnswer
    {
        [Key, Column(Order = 0)]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [Key, Column(Order = 1)]
        public int ChoiceId { get; set; }
        public Choice Choice { get; set; }
    }
}
