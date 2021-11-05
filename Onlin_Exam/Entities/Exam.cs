using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Online_Exam.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public string   Title { get; set; }
        public string Description { get; set; }
        public int   QuestionsCount { get; set; }

        // exam consist of  same qestions
        public int Score { get; set; }

        public int CategoryId { get; set; }
        public Category   Category { get; set; }

        public List<Question> Questions { get; set; }
    }
    public class ExamEntityConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.HasKey(k => k.Id);

            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            builder.Property(t => t.QuestionsCount)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("int");

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Exams)
                .HasForeignKey(f => f.CategoryId);
        }
    }
}
