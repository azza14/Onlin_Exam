using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrectAnswer { get; set; } = false;
        public int Score { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
       
    }
    public class ChoiceEntityConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.Property(e => e.Text)
               .IsRequired()
               .HasColumnType("nvarchar(50)");

            builder.HasKey(k => k.Id);

            builder.Property(d => d.Score)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(t => t.IsCorrectAnswer)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("bit");

            builder.HasOne(c => c.Question)
                .WithMany(c => c.Choices)
                .HasForeignKey(f => f.QuestionId);
        }
    }
}
