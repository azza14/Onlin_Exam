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
    public class TestsController : ControllerBase
    {
        private IGenericRepository<Test> _repository;
        private readonly IMapper _mapper;
        public TestsController(IGenericRepository<Test> repository , IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult   GetAll()
        {
            var listTest = _repository.GetAll();
            var result = _mapper.Map<IEnumerable<TestDTO>>(listTest);
            return Ok(result);
        }       
        // GET api/<TestsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
          //  var test = new Test();
            var test = _repository.GetById(id);
            if (test == null)
                return NotFound();
            else
            {
                return Ok(_mapper.Map<TestDTO>(test));
            }
        }

        // POST api/<TestsController>
        [HttpPost]
        public IActionResult Create([FromBody] TestDTO model)
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
                    //var test = new Test()
                    //{
                    //    Title = model.Title,
                    //    Description = model.Description,
                    //    QuestionsCount = model.QuestionsCount,
                    //    CategoryId = model.CategoryId
                    //};
                    var obj = _mapper.Map<Test>(model);
                    _repository.Insert(obj);
                    _repository.Save();
                    return Ok(_mapper.Map<TestDTO>(obj));
                }
            }
            catch
            {
                throw;
            }
        }

        // PUT api/<TestsController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TestDTO model)
        {
            var test = _repository.GetById(id);
            if (test == null)
                return NotFound();
          var editTest=  _mapper.Map(model, test);
            _repository.Update(editTest);
            _repository.Save();
            return Ok(new { message = " update Test success" });
        }

        // DELETE api/<TestsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var test = _repository.GetById(id);
            if (test == null)
                return NotFound();
            _repository.Delete(id);
            _repository.Save();
            return Ok();
        }
    }
}
