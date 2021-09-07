using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Onlin_Exam.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
        public string  Email { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        
        //public string ConfirmPassword { get; set; }
        public string Phone { get; set; }

    }
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public UserEntityConfiguration(){ }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                .HasColumnName("userName")
                .HasColumnType("nvarchar(50)")
                .IsRequired() ;

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("nvarchar(60)")
                .IsRequired();
        }
    }
}
