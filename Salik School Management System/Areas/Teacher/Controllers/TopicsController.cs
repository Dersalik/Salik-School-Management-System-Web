using Microsoft.AspNetCore.Mvc;

namespace Salik_School_Management_System.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TopicsController : Controller
    {
        public IActionResult Index()
        {
           return View();
        }
    }
}
