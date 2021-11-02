using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsCorrectAnswer { get; set; } = false;
        public int Score { get; set; }



        // Notes add Configuration

    }
}
