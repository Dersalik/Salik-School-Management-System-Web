using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Repository.IRepository;
using SchoolManagement.Models;

namespace Salik_School_Management_System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StageController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public StageController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var response =_unitOfWork.stage.GetAllFully();
            var responseTask = await response;
            IEnumerable<Stage> stages = (IEnumerable<Stage>)responseTask;
            return View(stages);
        }

        public async Task<IActionResult> AllStudents(int stNum)
        {

            if (stNum == 0)
            {
                return NotFound();
            }
            var response = _unitOfWork.stage.GetByStageNumber(k=>k.StageNumber==stNum);
            var responseTask = await response;
            Stage Stage = responseTask;
            if (Stage == null)
            {
                return NotFound();
            }
            return View(Stage);
        }
        public async Task<IActionResult> AllTopics(int stNum)
        {

            if (stNum == 0)
            {
                return NotFound();
            }
            var response = _unitOfWork.stage.GetByStageNumber(k => k.StageNumber == stNum);
            var responsetask = await response;
            Stage Stage = responsetask;

            if (Stage == null)
            {
                return NotFound();
            }
            return View(Stage);
        }
    }
}
