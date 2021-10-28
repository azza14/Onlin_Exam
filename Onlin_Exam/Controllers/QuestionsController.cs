using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Onlin_Exam.DTO;
using Onlin_Exam.Entities;
using Onlin_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Onlin_Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private IGenericRepository<Question> _repository;
        private readonly IMapper _mapper;
        public QuestionsController(IGenericRepository<Question> repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }
        // GET: api/<QuestionsController>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var listquestion = _repository.GetAll();
            var result = _mapper.Map<IEnumerable<QuestionAllDTO>>(listquestion);
            return Ok(result);
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //  var question = new question();
            var question = _repository.GetById(id);
            if (question == null)
                return NotFound();
            else
            {
                return Ok(_mapper.Map<QuestionDTO>(question));
            }
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public IActionResult Create([FromBody] QuestionDTO model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                else 
                {
                    var obj = _mapper.Map<Question>(model);
                    _repository.Insert(obj);
                    _repository.Save();
                    return Ok(_mapper.Map<QuestionDTO>(obj));
                }
            }
            catch
            {
                throw;
            }
        }

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionDTO model)
        {
            var question = _repository.GetById(id);
            if (question == null)
                return NotFound();
            var editquestion = _mapper.Map(model, question);
            _repository.Update(editquestion);
            _repository.Save();
            return Ok(new { message = " update question success" });
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var question = _repository.GetById(id);
            if (question == null)
                return NotFound();
            _repository.Delete(id);
            _repository.Save();
            return Ok();
        }
    }
}
