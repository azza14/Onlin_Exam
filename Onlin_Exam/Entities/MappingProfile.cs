﻿using AutoMapper;
using Onlin_Exam.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Entities
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Exam, ExamDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Question, QuestionAllDTO>().ReverseMap();
        }
    }
}
