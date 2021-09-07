using Onlin_Exam.Models;
using Onlin_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Auth
{
    public class AccountRepository: GenericRepository<User>
    {
        public AccountRepository(GenericRepository<User> repository):base( repository)
        {
            Repository = repository;
        }

        public GenericRepository<User> Repository { get; }
    }
    
}
