using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Repository.IRepository;
using SchoolManagement.Models;

namespace Salik_School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeacherController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            //IEnumerable<Teacher> teacher = (IEnumerable<Teacher>)_unitOfWork.teacher.GetAllFully().Result;
            var response = _unitOfWork.teacher.GetAllFully();
            var responseresult = await response;
            IEnumerable<Teacher> teacher = (IEnumerable<Teacher>)responseresult;
            return View(teacher);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher teac)
        {
            if (teac == null)
            {
                return NoContent();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.teacher.Add(teac);
                await _unitOfWork.Save();
                TempData["success"] = "Teacher registered successfully";
                return RedirectToAction("Index");
            }

              
                
            return View(teac);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {


            if (Id == 0)
            {
                return NotFound();

            }
            var response = _unitOfWork.teacher.GetFully(Id);
            var responseResult = await response;
            Teacher teacher = responseResult;
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.teacher.UpdateEntity(teacher);
                await _unitOfWork.Save();

                TempData["success"] = "Teacher details were edited successfully";
                return RedirectToAction("Index");

            }

            return View(teacher);
        }

        public async Task<IActionResult> DeleteAsync(int Id)
        {


            if (Id == 0)
            {
                return NotFound();

            }
            var response = _unitOfWork.teacher.GetFully(Id);
            var responseResult = await response;
            Teacher teacher = responseResult;
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Teacher t)
        {

            if (t == null)
            {
                return NotFound();
            }

            _unitOfWork.teacher.Remove(t);
            await _unitOfWork.Save();
            TempData["success"] = "teacher deleted successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AllTopicsAsync(int Id)
        {
            if(Id == 0)
            {
                return NotFound();
            }
            var response = _unitOfWork.teacher.GetFully(Id);
            var responseResult = await response;
            Teacher teacher = responseResult;

            //teacher.topics =  (List<Topic>?)  _unitOfWork.topic.GetAllFullyByTeacherId(teacher.Id).Result;
            var response2 = _unitOfWork.topic.GetAllFullyByTeacherId(teacher.Id);
            var responeresult2 = await response2;
            teacher.topics = responeresult2;
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
    }
}
