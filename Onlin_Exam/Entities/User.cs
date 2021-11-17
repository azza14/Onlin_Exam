using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Role  Role { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
       // [NotMapped]
       // public string Token { get; set; }

    }
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public UserEntityConfiguration() { }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                .HasColumnName("userName")
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("nvarchar(50)")
                .IsRequired();
        }
    }
}
