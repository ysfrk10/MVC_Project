using GymBL.DTOS;
using GymBL.Interfaces;
using GymPL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GymPL.Controllers
{
    public class GymController : Controller
    {
        #region D INJECT    
        private readonly IGymService _service;
        public GymController(IGymService service)
        {
            _service = service;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var members = _service.ViewAllMember();
            return View(members);
        }
        #endregion

        #region AddMember 
        [HttpGet]
        public IActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMember(AddVm member)
        {
            _service.AddMember(new AddDTO()
            {
                Name = member.Name,
                JoinDate = member.JoinDate,
                PhoneNumber = member.PhoneNumber,
            });
            return RedirectToAction("Index");
        }
        #endregion

        #region View Details
        public IActionResult Details(int id)
        {
            var member = _service.GetMember(id);

            // 🔥 الأهم: اتأكد من الـ DTO مش null
            if (member == null)
            {
                // لو مش موجود، ارجع 404
                return NotFound($"Member with ID {id} not found");
            }

            return View(member);
        }
        #endregion

        #region EditMember
        [HttpGet]
        public IActionResult EditMember(int id)
        {
            // جلب العضو من قاعدة البيانات
            var member = _service.GetMember(id);

            if (member == null)
            {
                return NotFound();
            }

            var editVM = new EditVM
            {
                Id = member.Id,
                Name = member.Name,
                PhoneNumber = member.PhoneNumber,
                JoinDate = member.JoinDate,

            };
            return View(editVM);
        }
        [HttpPost]
        public IActionResult EditMember(EditVM e)
        {
            if (ModelState.IsValid)
            {
                _service.EditMember(new EditDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    PhoneNumber = e.PhoneNumber,
                    JoinDate = e.JoinDate,
                });
                return RedirectToAction("Index");
            }

            return View(e);
        }
        #endregion

        #region Remove Member
        public IActionResult RemoveMember(int id)
        {
            _service.ReomveMember(id);
            return RedirectToAction("Index");
        }
        #endregion




    }
}