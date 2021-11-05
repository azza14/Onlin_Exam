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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<CorrectAnswer>()
        //        .HasKey(ca => new { ca.QuestionId, ca.ChoiceId });

        //    modelBuilder.Entity<CorrectAnswer>()
        //                .HasOne<Question>(ca => ca.Question)
        //                .WithMany(q => q.CorrectAnswers)
        //               .HasForeignKey(ca => ca.QuestionId)
        //               .OnDelete(DeleteBehavior.Restrict);


        //    modelBuilder.Entity<CorrectAnswer>()
        //               .HasOne<Choice>(ca => ca.Choice)
        //               .WithMany(q => q.CorrectAnswers)
        //               .HasForeignKey(ca => ca.ChoiceId)
        //               .OnDelete(DeleteBehavior.Restrict);

        //    //modelBuilder.Entity<CorrectAnswer>()
        //    //    .HasMany(i => i.Question)
        //    //    .WithRequired()
        //    //    .WillCascadeOnDelete(false);

        //    //    modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        //    //    modelBuilder.ApplyConfiguration(new ExamEntityConfiguration());
        //}
    }
}
