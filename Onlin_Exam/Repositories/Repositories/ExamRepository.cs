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
                            Score= exam.Score,
                            CategoryName = c.Name
                        }).ToList();
            return list;
        }
        public ExamSingleDTO GetExamsDetails(int id)
        {
            var exam = (from ex in _context.Exams
                        join c in _context.Categories

                        on ex.CategoryId equals c.Id 
                        where ex.Id ==id                      
                        select new ExamSingleDTO
                        {
                            Id = ex.Id,
                            Title = ex.Title,
                            Description = ex.Description,
                            CategoryName = c.Name,
                            CategoryId=c.Id,
                            QuestionsCount = ex.QuestionsCount,
                            Score = ex.Score
                        }).FirstOrDefault();

            return exam;

        }
        public List<Exam> GetAllExams()
        {
            var list = GetAll();
            return list;
        }
    }
}
