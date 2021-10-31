using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Entities
{
    public class CorrectAnswer
    {
        [Key, Column(Order = 0)]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [Key, Column(Order = 1)]
        public int ChoiceId { get; set; }
        public Choice Choice { get; set; }

        public string Notes { get; set; }
        public int Score { get; set; }
        public class CorrectAnswerEntityConfiguration : IEntityTypeConfiguration<CorrectAnswer>
        {
            public void Configure(EntityTypeBuilder<CorrectAnswer> builder)
            {
                builder.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");


                builder.Property(d => d.Score)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnType("int");
            }
        }
    }
}
