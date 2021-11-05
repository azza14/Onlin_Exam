using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Online_Exam.DTO;
using Online_Exam.Entities;
using Online_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private IGenericRepository<Question> _questionRepo;
        private readonly IGenericRepository<Choice> _choiceRepo;

        private readonly IMapper _mapper;
        #region Constructor
        public QuestionsController(
                     IGenericRepository<Question> repository,
                     IMapper mapper,
                     IGenericRepository<Choice> choiceRepo
                     )
        {
            this._questionRepo = repository;
            _mapper = mapper;
            _choiceRepo = choiceRepo;
        }
        #endregion
        #region Gets
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var listquestion = _questionRepo.GetAll();
            var result = _mapper.Map<IEnumerable<QuestionDTO>>(listquestion);
            return Ok(result);
        }
        [HttpGet("GetQuestionsWithChoices")]
        public IActionResult GetQuestionsWithChoices()
        {
            var listquestion = _questionRepo.GetAll(q=>q.Choices);
            var result = _mapper.Map<IEnumerable<QuestionDTO>>(listquestion);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //  var question = new question();
            var question = _questionRepo.GetById(id);
            if (question == null)
                return NotFound();
            else
            {
                return Ok(_mapper.Map<QuestionDTO>(question));
            }
        }
        #endregion 
        #region CreateQuestion
        [HttpPost("CreateQuestion")]
        public IActionResult Create([FromBody] AddQuestionDTO model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                else
                {
                    var question = _mapper.Map<Question>(model);
                    var returnChoices = _questionRepo.InsertWithReturn(question);
                    _questionRepo.Save();
                    return Ok(_mapper.Map<AddQuestionDTO>(returnChoices));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region manualMapping
        //public IActionResult Create([FromBody] AddQuestionDTO model)
        //{
        //    try
        //    {
        //        if (model == null)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            var question = new Question();

        //            question.Text = model.Text;
        //            question.Degree = model.Degree;
        //            question.ExamId = model.ExamId;

        //            var returnChoices = _questionRepo.InsertWithReturn(question);

        //            var choicesList = new List<Choice>();
        //            foreach (var c in model.Choices)
        //            {
        //                var choice = new Choice
        //                {
        //                    Id = model.Id,
        //                    QuestionId = returnChoices.Id,
        //                    Text = model.Text,
        //                };
        //                choicesList.Add(choice);
        //            }

        //            question.Choices = choicesList;
        //            var tt = _choiceRepo.InsertWithRange(question.Choices);
        //            _questionRepo.Save();
        //            return Ok(_mapper.Map<AddQuestionDTO>(question));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region UpdateQuestion
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionDTO model)
        {
            var question = _questionRepo.GetById(id);
            if (question == null)
                return NotFound();
            var editquestion = _mapper.Map(model, question);
            _questionRepo.Update(editquestion);
            _questionRepo.Save();
            return Ok(new { message = " update question success" });
        }
        #endregion
        #region DeleteQuestion
        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var question = _questionRepo.GetById(id);
            if (question == null)
                return NotFound();
            _questionRepo.Delete(id);
            _questionRepo.Save();
            return Ok();
        }
        #endregion


    }
}
