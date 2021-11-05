using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    public class SubjectEntityConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(c => c.Id)
                .HasColumnType("int")
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("Name")
                .IsRequired();

            builder.HasOne(c => c.Category)
               .WithMany(c => c.Subjects)
               .HasForeignKey(f => f.CategoryId);

           

        }
    }
}
