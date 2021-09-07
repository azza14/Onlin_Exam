using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Onlin_Exam.Controllers
{
    public class Response 
    {
        public string Status { get; set; }
        public string Message { get; set; }

        //public Task ExecuteResultAsync(ActionContext context)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}