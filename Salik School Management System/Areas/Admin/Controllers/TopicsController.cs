using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Repository.IRepository;
using SchoolManagement.Models;


namespace Salik_School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TopicsController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        public TopicsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> IndexAsync()
        {

            //IEnumerable<Topic> topicList = (IEnumerable<Topic>)_unitOfWork.topic.GetAllFully().Result;

            var response = _unitOfWork.topic.GetAllFully();
            var responseresult = await response;
            IEnumerable<Topic> topicList = (IEnumerable<Topic>)responseresult;
            return View(topicList);
        }

        public async Task<IActionResult> EditAsync(int Id)
        {
            if(Id == 0)
            {
                return NotFound();
            }
            //Topic topicToEdit = _unitOfWork.topic.GetFully(Id).Result;

            var response = _unitOfWork.topic.GetFully(Id);
            var responseResult = await response;
            Topic topicToEdit = responseResult;

            if (topicToEdit == null)
            {
                return NotFound(Id);
            }
            return View(topicToEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Topic topic)
        {
            if(topic == null)
            {
                return NotFound();
            }
            _unitOfWork.topic.UpdateEntity(topic);
            await  _unitOfWork.Save();
            TempData["success"] = "Topic details edited successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AllStudentsAsync(int Id)
        {
            //Topic topic = _unitOfWork.topic.GetFully(Id).Result;
            var response = _unitOfWork.topic.GetFully(Id);
            var responseResult = await response;
            Topic topic = responseResult;


            //topic.Stage=_unitOfWork.stage.GetFully(topic.StageId).Result;
            var response2 = _unitOfWork.stage.GetFully(topic.StageId);
            var responseResult2 = await response2;
            topic.Stage = responseResult2;
            return View(topic);
        }
        [HttpGet]
        public async Task<IActionResult> AssignTeacherAsync(int Id)
        {
            //Topic topic = _unitOfWork.topic.GetFully(Id).Result;
            var response = _unitOfWork.topic.GetFully(Id);
            var responseResult = await response;
            Topic topic = responseResult;
            //IEnumerable<Teacher> teachers = (IEnumerable<Teacher>)_unitOfWork.teacher.GetAllFully().Result;

            var response2 = _unitOfWork.teacher.GetAllFully();
            var responseresult2 = await response2;
            IEnumerable<SchoolManagement.Models.Teacher> teachers = (IEnumerable<SchoolManagement.Models.Teacher>)responseresult2;
            TempData.Add("Id", Id);
            return View(teachers);
        }

        //to be tested 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignTeacher( int Id, int TopicId)
        {
            var response = _unitOfWork.topic.GetFully(Id);
            var responseResult = await response;
            Topic topic = responseResult;
            // Topic topic = _unitOfWork.topic.GetFully(TopicId).Result;

            var response2 = _unitOfWork.teacher.GetFully(Id);
            var responseResult2 = await response2;
            SchoolManagement.Models.Teacher teacher = responseResult2;
          //  Teacher teacher = _unitOfWork.teacher.GetFully(Id).Result;
            topic.teacher = teacher;
            teacher?.topics?.Add(topic);

            if (teacher.topics.Contains(topic))
            {
                teacher.topics.Remove(topic);
            }

            await _unitOfWork.Save();
            TempData["success"] = "teacher was assigned successfully";
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveTeacher(int Id, int TopicId)
        {
            var response = _unitOfWork.topic.GetFully(Id);
            var responseResult = await response;
            Topic topic = responseResult;
            //Topic topic = _unitOfWork.topic.GetFully(TopicId).Result;
            var response2 = _unitOfWork.teacher.GetFully(Id);
            var responseResult2 = await response2;
            SchoolManagement.Models.Teacher teacher = responseResult2;
           // Teacher teacher = _unitOfWork.teacher.GetFully(Id).Result;
            topic.teacher =null;
            

            if (teacher.topics.Contains(topic))
            {
                teacher.topics.Remove(topic);
            }

            await _unitOfWork.Save();
            TempData["success"] = "teacher was Removed successfully";
            return RedirectToAction("Index");

        }
    }
}
