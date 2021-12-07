using AutoMapper;
using Online_Exam.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Entities
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDTO, User>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();

            CreateMap<SubjectDTO, Subject>().ReverseMap();

            CreateMap<Exam, ExamDTO>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions))
                .ReverseMap();

            CreateMap<Exam, ExamSingleDTO>()
              .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
              .ReverseMap();
            
            CreateMap<Question, QuestionDTO>()
                .ReverseMap();

            CreateMap<Choice, ChoiceDTO>()
                .ReverseMap();

            CreateMap<Choice, AddQuestionDTO>()
                .ReverseMap();


            CreateMap<Question, AddQuestionDTO>()
             .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices))
             .ReverseMap();

            

        }
    }
}
