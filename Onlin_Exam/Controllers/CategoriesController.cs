using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class CategoriesController : ControllerBase
    {
        private IGenericRepository<Category> _repository;
        private IMapper _mapper;
        #region Constructor
        public CategoriesController(
                        IGenericRepository<Category> repository, 
                        IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        #endregion
        #region Get
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
        #endregion
        #region CreateCategory
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
        }
        #endregion
        #region UpdateSubject
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
        #endregion
        #region DeleteCategory
        [HttpDelete("Delete")]
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                return BadRequest();
                    _repository.Delete(id.Value);
                _repository.Save();
                return Ok( new { message = "delete category success" });
            }
            catch
            {
                throw;
            }
           
        }
        #endregion
    }
}
