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
        public CategoriesController(IGenericRepository<Category> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryList = _repository.GetAll();
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null)
                return BadRequest();
            var category = _repository.GetById(id.Value);
            return Ok(category);
        }
       
        [HttpPost]
        public IActionResult Create([FromBody] CategoryViewModel model)
        {
            try
            {
                if(model != null)
                {
                    var category = new Category()
                    {
                        Id = model.Id,
                        Name = model.Name
                    };
                    _repository.Insert(category);
                    _repository.Save();
                }
            }
            catch
            {
                throw;
            }
            return Ok( new {  message= " create category success"});
        }

        [HttpPut("Update")]
        public IActionResult Update(int id,[FromBody] CategoryViewModel model)
        {
            var category = _repository.GetById(id);
               category.Id = id;
               category.Name = model.Name;

             _repository.Update(category);
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
                return Ok( new { message = " delete category success" });
            }
            catch
            {
                throw;
            }
           
        }
    }
}
