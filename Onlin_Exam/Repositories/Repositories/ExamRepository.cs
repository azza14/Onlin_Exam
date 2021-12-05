using Online_Exam.DBContext;
using Online_Exam.DTO;
using Online_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Repositories.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly OnlineDbContext _context;
        public ExamRepository(OnlineDbContext context) 
            : base(context)
        {
            _context = context;
        }

        public List<ExamListDTO> GetExams()
        {
            var list = (from exam in _context.Exams
                        join c in _context.Categories
                        on exam.CategoryId equals c.Id
                        select new ExamListDTO
                        {
                            Id = exam.Id,
                            Title = exam.Title,
                            Description = exam.Description,
                            QuestionsCount = exam.QuestionsCount,
                            CategoryName = c.Name
                        }).ToList();
            return list;
        }

        public List<Exam> GetAllExams()
        {
            var list = GetAll();
            return list;
        }
    }
}
