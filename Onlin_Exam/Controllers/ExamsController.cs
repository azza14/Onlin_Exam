using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Online_Exam.DTO;
using Online_Exam.Entities;
using Online_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private IGenericRepository<Exam> _examRepo;
        private readonly IMapper _mapper;
        #region Constructor
        public ExamsController(IGenericRepository<Exam> repository, 
            IMapper mapper)
        {
            this._examRepo = repository;
            _mapper = mapper;
        }
        #endregion
        #region Get
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var listExam = _examRepo.GetAll();
            var result = _mapper.Map<IEnumerable<ExamDTO>>(listExam);
            return Ok(result);
        }
        [HttpGet("GetExamWithQuestions")]
        public IActionResult GetExamsWithQuestions()
        {
            var listExam = _examRepo.GetAll(x=>x.Questions);
            var result = _mapper.Map<IEnumerable<ExamDTO>>(listExam);
            return Ok(result);
        }
        // GET api/<ExamsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
          //  var Exam = new Exam();
            var Exam = _examRepo.GetById(id);
            if (Exam == null)
                return NotFound();
            else
            {
                return Ok(_mapper.Map<ExamDTO>(Exam));
            }
        }
        #endregion
        #region CerateExam
        [HttpPost]
        public IActionResult Create([FromBody] ExamDTO model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                else 
                {
                    var exam = _mapper.Map<Exam>(model);
                    var examReturn = _examRepo.InsertWithReturn(exam);;
                    _examRepo.Save();
                    return Ok(_mapper.Map<ExamDTO>(examReturn));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
        #region UpdateExam
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ExamDTO model)
        {
            var Exam = _examRepo.GetById(id);
            if (Exam == null)
                return NotFound();
          var editExam=  _mapper.Map(model, Exam);
            _examRepo.Update(editExam);
            _examRepo.Save();
            return Ok(new { message = " update Exam success" });
        }
        #endregion
        #region deleteExam
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Exam = _examRepo.GetById(id);
            if (Exam == null)
                return NotFound();
            _examRepo.Delete(id);
            _examRepo.Save();
            return Ok();
        }
        #endregion
        #region test
        //public IActionResult GetFile()
        //{
        //    string testFile = HttpContext.Current.Server.MapPath("~/test.txt");
        //    var result = new { testFile };
        //    return Ok ();
        //}
        #endregion



    }
}
