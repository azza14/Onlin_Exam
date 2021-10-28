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
    public class ExamsController : ControllerBase
    {
        private IGenericRepository<Exam> _repository;
        private readonly IMapper _mapper;
        public ExamsController(IGenericRepository<Exam> repository , IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult   GetAll()
        {
            var listExam = _repository.GetAll();
            var result = _mapper.Map<IEnumerable<ExamDTO>>(listExam);
            return Ok(result);
        }       
        // GET api/<ExamsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
          //  var Exam = new Exam();
            var Exam = _repository.GetById(id);
            if (Exam == null)
                return NotFound();
            else
            {
                return Ok(_mapper.Map<ExamDTO>(Exam));
            }
        }

        // POST api/<ExamsController>
        [HttpPost]
        public IActionResult Create([FromBody] ExamDTO model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                else //(model != null)
                {
                    //try to use automapper 
                    //var Exam = new Exam()
                    //{
                    //    Title = model.Title,
                    //    Description = model.Description,
                    //    QuestionsCount = model.QuestionsCount,
                    //    CategoryId = model.CategoryId
                    //};
                    var obj = _mapper.Map<Exam>(model);
                    _repository.Insert(obj);
                    _repository.Save();
                    return Ok(_mapper.Map<ExamDTO>(obj));
                }
            }
            catch
            {
                throw;
            }
        }

        // PUT api/<ExamsController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ExamDTO model)
        {
            var Exam = _repository.GetById(id);
            if (Exam == null)
                return NotFound();
          var editExam=  _mapper.Map(model, Exam);
            _repository.Update(editExam);
            _repository.Save();
            return Ok(new { message = " update Exam success" });
        }

        // DELETE api/<ExamsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Exam = _repository.GetById(id);
            if (Exam == null)
                return NotFound();
            _repository.Delete(id);
            _repository.Save();
            return Ok();
        }
    }
}
