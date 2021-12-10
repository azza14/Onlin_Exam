using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.DTO
{
    public class CategoryDTO
    {
       public int Id { get; set; }
      //  [Required]
        //[StringLength(20, MinimumLength = 6,
        //    ErrorMessage = "Name Category  must be greater than 6 characters and less than 20 characters")]
        public string Name { get; set; }

        //public List<Exam> Exams { get; set; }
    }
}
