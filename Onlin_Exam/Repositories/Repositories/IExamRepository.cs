using Online_Exam.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Repositories.Repositories
{
    public interface IExamRepository
    {
        List<ExamListDTO> GetExams();
    }
}
