using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Repository.IRepository;
using SchoolManagement.Models;

namespace Salik_School_Management_System.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TeachersController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public TeachersController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var result = await _unitOfWork.teacher.GetAll();
            var teachers = result;

            return View(teachers);
        }


        public async Task<IActionResult> AllTopics(int Id)
        {


            if (Id == 0)
            {
                return NotFound();

            }

            //var student = _unitOfWork.student.GetFully(Id).Result;

            var response1 = _unitOfWork.teacher.GetFully(Id);
            var responseResult = await response1;
            SchoolManagement.Models.Teacher teacher = responseResult;

            var response2 = _unitOfWork.topic.GetAllFullyByTeacherId(teacher.Id);
            var result =  await response2;
            teacher.topics = result;

            return View(teacher);

        }

        public async Task<IActionResult> StudentTopic(int Id)
        {
            if (Id == 0) return NotFound();

            var response=(IEnumerable<SchoolManagement.Models.StudentTopic>)_unitOfWork.studenTopic.GetAllWitStudentById(Id);
           
          foreach (var topic in response)
            {
                topic.TopicId = Id;
            }
            

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGrade(StudentTopic stdt,int grade)
        {
            if (stdt == null) return NotFound();
            stdt.grade = grade;
             if(stdt.grade > 50)
            {
                stdt.isPassedTopic = true;
            }
            else { stdt.isPassedTopic = false; }

             _unitOfWork.studenTopic.UpdateEntity(stdt);
            await _unitOfWork.Save();

            int v = (int)stdt.TopicId;
            return RedirectToAction("StudentTopic", new {Id= v });
        }

    }
}
