using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string    Name { get; set; }

        public  virtual  List<Test> Tests { get; set; }
    }
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id).HasColumnType("int")
                .HasColumnName("Id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name).HasColumnType("nvarchar(50)")
              .HasColumnName("Name")
              .IsRequired();
        }
    }
}
