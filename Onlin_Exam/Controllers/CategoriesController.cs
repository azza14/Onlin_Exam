using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onlin_Exam.DTO;
using Onlin_Exam.Entities;
using Onlin_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onlin_Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IGenericRepository<Category> _repository;
        private IMapper _mapper;
        public CategoriesController(IGenericRepository<Category> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryList = _repository.GetAll();
            var result= _mapper.Map<IEnumerable<CategoryDTO>>(categoryList);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();
            var category = _repository.GetById(id.Value);
            var result = _mapper.Map<CategoryDTO>(category);
            return Ok(result);
        }
       
        [HttpPost]
        public IActionResult Create([FromBody] CategoryDTO model)
        {
             try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                else 
                {
                    var obj = _mapper.Map<Category>(model);
                    _repository.Insert(obj);
                    _repository.Save();
                    return Ok(_mapper.Map<CategoryDTO>(obj));
                }
            }
            catch
            {
                throw;
            }
            //return Ok( new {  message= " create category success"});
        }

        [HttpPut("Update")]
        public IActionResult Update(int id,[FromBody] CategoryDTO model)
        {
            var category = _repository.GetById(id);
            if (category == null)
                return NotFound();
            var editCategory = _mapper.Map(model, category);

             _repository.Update(editCategory);
            _repository.Save();

            return Ok(new  {  message= " update category success"});
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int? id)
        {
            //if (id == null)
            //    return BadRequest();
            //var category = _repository.GetById(id.Value);
            try
            {
                _repository.Delete(id.Value);
                _repository.Save();
                return Ok( new { message = "delete category success" });
            }
            catch
            {
                throw;
            }
           
        }
    }
}
