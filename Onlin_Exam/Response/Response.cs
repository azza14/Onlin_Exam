using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Online_Exam.Controllers
{
    public class Response 
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }

    }
}