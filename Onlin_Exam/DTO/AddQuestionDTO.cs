﻿using Onlin_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.DTO
{
    public class AddQuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Degree { get; set; }
        public int ExamId { get; set; }

        public List<ChoiceDTO> Choices { get; set; }
        //public List<CorrectAnswerDTO> CorrectAnswers { get; set; }




    }
}
