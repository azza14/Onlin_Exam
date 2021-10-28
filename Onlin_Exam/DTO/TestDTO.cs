using Onlin_Exam.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.DTO
{
    public class ExamDTO
    {
      //  public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int QuestionsCount { get; set; }
        public int CategoryId { get;  set; }
    }
   


}
