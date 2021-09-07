using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Onlin_Exam.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string   Title { get; set; }
        public string Description { get; set; }
        public int   QuestionsCount { get; set; }


        public int CategoryId { get; set; }
        public Category   Category { get; set; }

        public List<Question> Questions { get; set; }

    }
    public class TestEntityConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
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

            //relations
            builder.HasOne<Category>(c => c.Category)
                .WithMany(c => c.Tests)
                .HasForeignKey(f => f.CategoryId);




        }

       
    }
}
