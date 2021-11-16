using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Exam.DBContext;
using Online_Exam.DTO;
using Online_Exam.Entities;
using Online_Exam.Repositories;

namespace Online_Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private IGenericRepository<Subject> _repository;
        private IMapper _mapper;
        #region Constructor
        public SubjectsController(IGenericRepository<Subject> repository, 
                                    IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        #endregion
        #region Get
        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjectList = _repository.GetAll();
            var result = _mapper.Map<IEnumerable<SubjectDTO>>(subjectList);
            return Ok(result);
        }
        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public IActionResult GetSubject(int id)
        {
            var subject = _repository.GetById(id);
            if (subject == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<CategoryDTO>(subject);
            return Ok(result);
        }

        #endregion
        #region UpdateSubject
        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public IActionResult PutSubject(int id,  [FromBody]  SubjectDTO model)
        {
            var subject = _repository.GetById(id);
            if (subject == null)
                return NotFound();
            var editCategory = _mapper.Map(model, subject);

            _repository.Update(editCategory);
            try
            {
                _repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

                return Ok(new { message = " update subject success" });
        }
        #endregion
        #region CreateSubject
        // POST: api/Subjects
        [HttpPost]
        public IActionResult CreateSubject(SubjectDTO subject)
        {
            try
            {
                if (subject == null)
                {
                    return BadRequest();
                }
                else
                {
                    var obj = _mapper.Map<Subject>(subject);
                    _repository.Insert(obj);
                    _repository.Save();
                    return Ok(_mapper.Map<SubjectDTO>(obj));
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region DeleteSubject
        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int? id)
        {
            try
            {
                var subject = _repository.GetById(id.Value);
                if (subject == null)
                {
                    return NotFound();
                }
                _repository.Delete(id.Value);
                _repository.Save();
                return Ok(new { message = "delete category success" });
            }
            catch
            {
                throw;
            }
        }

        #endregion
        private bool SubjectExists(int id)
        {
            return _repository.IsExists(e => e.Id == id);
        }
    }
}
