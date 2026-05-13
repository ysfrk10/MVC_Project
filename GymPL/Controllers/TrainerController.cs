using GymBL.DTOS;
using GymBL.DTOS.TrainerDTOS;
using GymBL.Interfaces;
using GymDAL.Entities;
using GymPL.Helper;
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
            string ImageName = UploadFiles.Upload("images", trainer.ImgPath);
            _service.AddTrainer(new AddTrainerDTO()
            {
                Name = trainer.Name,
                PhoneNumber = trainer.PhoneNumber,
                ImgPath = ImageName

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
        [HttpGet]
        public IActionResult EditTrainer(int id)
        {
            var trainer = _service.GetTrainers(id);


            if (trainer == null)
            {
                return NotFound();
            }
            var eVM = new EditTrainerVM()
            {
                Name = trainer.Name,
                Id = trainer.Id,
                PhoneNumber = trainer.PhoneNumber,
            };
            return View(eVM);
        }
        [HttpPost]
        public IActionResult EditTrainer(EditTrainerVM e)
        {
            _service.EditTrainer(new AddTrainerDTO
            {
                Id = e.Id,
                Name = e.Name,
                PhoneNumber = e.PhoneNumber,
            });
            return RedirectToAction("Index", "Trainer");
        }

        #endregion

        #region Remove Member
        public IActionResult RemoveTrainer(int id)
        {
            _service.ReomveTrainer(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
