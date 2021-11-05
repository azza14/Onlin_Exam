using Microsoft.EntityFrameworkCore;
using Online_Exam.Entities;

namespace Online_Exam.DBContext
{
    public class OnlineDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public OnlineDbContext()
        {
        }

        public OnlineDbContext(DbContextOptions<OnlineDbContext> options):base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamSession> ExamSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExamEntityConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ChoiceEntityConfiguration());
        }
    }
}
