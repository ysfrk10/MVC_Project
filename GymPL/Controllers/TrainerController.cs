using GymBL.DTOS;
using GymBL.DTOS.TrainerDTOS;
using GymBL.Interfaces;
using GymPL.ViewModel;
using GymPL.ViewModel.Trainer;
using Microsoft.AspNetCore.Mvc;

namespace GymPL.Controllers
{
    public class TrainerController : Controller
    {
        #region Depandancy injection
        private readonly ITrainerService _service;
        public TrainerController(ITrainerService service)
        {
            _service = service;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var treiners = _service.ViewAllTrainers();
            return View(treiners);
        }
        #endregion

        #region AddMember 
        [HttpGet]
        public IActionResult AddTrainer()
        {
            return RedirectToAction("AddMember", "Gym");
        }

        [HttpPost]
        public IActionResult AddTrainer(AddTrainerVM trainer)
        {
            _service.AddTrainer(new AddTrainerDTO()
            {
                Name = trainer.Name,
                PhoneNumber = trainer.PhoneNumber,
                ImgPath = trainer.ImgPath,
            });
            return RedirectToAction("Index", "Trainer");
        }
        #endregion

        #region View Details
        //public IActionResult Details(int id)
        //{

        //}
        #endregion

        #region EditMember
        //[HttpGet]
        //public IActionResult EditMember(int id)
        //{

        //}
        //[HttpPost]
        //public IActionResult EditMember(EditVM e)
        //{

        //}
        #endregion

        #region Remove Member
        //public IActionResult RemoveMember(int id)
        //{

        //}
        #endregion
    }
}
