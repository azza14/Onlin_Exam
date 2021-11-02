using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Degree { get; set; }
        // level 1:5
        public int DifficultLevel { get; set; }

        public int ExamId { get; set; }
        public Exam  Exam{ get; set; }

        public List<Choice> Choices { get; set; }

       // public List<CorrectAnswer> CorrectAnswers { get; set; }
        ///Notes Add Configurations
        public class QuestionEntityConfiguration : IEntityTypeConfiguration<Question>
        {
            public void Configure(EntityTypeBuilder<Question> builder)
            {
                builder.HasKey(k => k.Id);

                builder.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");

                builder.Property(d => d.Degree)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("int");
                builder.HasOne<Exam>(c => c.Exam)
                .WithMany(c => c.Questions)
                .HasForeignKey(f => f.ExamId);
            }
        }

    }
}
