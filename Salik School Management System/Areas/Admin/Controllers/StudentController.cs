using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Repository.IRepository;
using SchoolManagement.Models;

namespace Salik_School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {

            //IEnumerable<Student> listOfAllStudents

            var response = _unitOfWork.student.GetAllFully();
            var responseTask = await response;

            IEnumerable<Student> listOfAllStudents = (IEnumerable<Student>)responseTask;



            return View(listOfAllStudents);
        }
        public IActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std,int stNum)
        {

            if(stNum > 6 || stNum < 1)
            {
                return new NotFoundResult();
            }

            var response = _unitOfWork.stage.GetByStageNumber(k => k.StageNumber == stNum);
            Stage stage = await response;
            

            if (ModelState.IsValid)
            {
                StudentTopic st0 = new StudentTopic()
                {
                    student = std,
                    topic = stage.topicList.ElementAt(0)

                };

                StudentTopic st1 = new StudentTopic()
                {
                    student = std,
                    topic = stage.topicList.ElementAt(1)

                };

                StudentTopic st2 = new StudentTopic()
                {
                    student = std,
                    topic = stage.topicList.ElementAt(2)

                }; 
                StudentTopic st3 = new StudentTopic()
                {
                    student = std,
                    topic = stage.topicList.ElementAt(3)

                };


                List<StudentTopic> ls = new List<StudentTopic>();
                ls.AddRange(new List<StudentTopic>() { st0,st1,st2,st3});
                //        Console.WriteLine(ls.ElementAt(0).topic.Name);
                std.topics = ls;
                std.stage = stage;
                _unitOfWork.student.Add(std);
              await  _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(std);
        }
        [HttpGet]
       public async Task<IActionResult> Edit(int Id)
        {


            if (Id == 0)
            {
                return NotFound();

            }
            var response = _unitOfWork.student.GetFully(Id);
            Student student = await response;
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student, int stNum)
        {


            if (ModelState.IsValid)
            {

                if (stNum > 6 || stNum < 1)
                {
                    return new NotFoundResult();
                }
                //.Where(k => k.StudentId == student.Id).ToList()

                //student.topics = _unitOfWork.studenTopic.GetAll().Result.Where(k => k.StudentId == student.Id).ToList();

                var response = _unitOfWork.studenTopic.GetAll();
                var responsetask = await response;
                student.topics = responsetask.Where(k => k.StudentId == student.Id).ToList();

                if (student?.stage?.StageNumber != stNum)
                {


                   
                    _unitOfWork.studenTopic.RemoveRange(student.topics);
                    student.stage=null;

                     

                    _unitOfWork.student.UpdateEntity(student);
                    await _unitOfWork.Save();

                    //before
                    //Stage stage = _unitOfWork.stage.GetFirstOrDefault(l=>l.StageNumber== stNum).Result;
                    //correct wait to get the result way by async
                    var response1 = _unitOfWork.stage.GetFirstOrDefault(l => l.StageNumber == stNum);
                    var responsest=await response1;
                    Stage stage =  responsest;


                    //stage.topicList = _unitOfWork.topic.GetAll().Result.Where(k => k.StageId == stage.Id).ToList();

                    var topresponse = _unitOfWork.topic.GetAll();
                    var responsetopawait = await topresponse;
                    stage.topicList=responsetopawait.Where(k => k.StageId == stage.Id).ToList();


                    //stage.students = _unitOfWork.student.GetAll().Result.Where(k => k.StageId == stage.Id).ToList();

                    var stdResponse = _unitOfWork.student.GetAll();
                    var stdresponseResult = await stdResponse;
                    stage.students= stdresponseResult.Where(k => k.StageId == stage.Id).ToList();

                    stage.students.Add(student);
                    student.stage = stage;
                    StudentTopic st0 = new StudentTopic()
                    {
                        student = student,
                        topic = stage.topicList.ElementAt(0)

                    };

                    StudentTopic st1 = new StudentTopic()
                    {
                        student = student,
                        topic = stage.topicList.ElementAt(1)

                    };

                    StudentTopic st2 = new StudentTopic()
                    {
                        student = student,
                        topic = stage.topicList.ElementAt(2)

                    };
                    StudentTopic st3 = new StudentTopic()
                    {
                        student = student,
                        topic = stage.topicList.ElementAt(3)

                    };

                    
                    List<StudentTopic> ls = new();
                    ls.AddRange(new List<StudentTopic>() { st0, st1, st2, st3 });
                    // _unitOfWork.studenTopic.RemoveRange(student.topics);
                    
                    student.topics.AddRange(ls);

                }



                _unitOfWork.student.UpdateEntity(student);
               await _unitOfWork.Save();
                TempData["success"] = "Student information edited successfully";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            

            if (Id == 0)
            {
                return NotFound();

            }

            var response = _unitOfWork.student.GetFully(Id);
            var responseResult = await response;
            Student student = responseResult;
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Student std)
        {

            if (std == null)
            {
                return NotFound();
            }

            _unitOfWork.student.Remove(std);
           await _unitOfWork.Save();
            TempData["success"] = "student deleted successfully";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AllTopics(int Id)
        {
            

            if (Id == 0)
            {
                return NotFound();

            }

            //var student = _unitOfWork.student.GetFully(Id).Result;

            var response1 = _unitOfWork.student.GetFully(Id);
            var responseResult = await response1;
            Student student = responseResult;


            student.stage =  _unitOfWork.stage.GetFully(student.StageId).Result;

            var response2 = _unitOfWork.stage.GetFully(student.StageId);
            var response2result= await response2;
            student.stage = response2result;
            return View(student);
             
        }



    }
}
