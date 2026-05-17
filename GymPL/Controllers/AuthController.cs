using GymDAL.Entities;
using GymPL.Mapping;
using GymPL.ViewModel.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static GymPL.ViewModel.Auth.CreateUserVM;

namespace GymPL.Controllers
{
    public class AuthController : Controller
    {
        #region Depandancy injection
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthController(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Gym");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateUserVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Make sure the username isn't already taken
            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "This username is already taken.");
                return View(model);
            }

            // Make sure the email isn't already registered
            var existingEmail = await _userManager.FindByEmailAsync(model.Email);
            if (existingEmail != null)
            {
                ModelState.AddModelError(nameof(model.Email), "An account with this email already exists.");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Sign the user in immediately after registration
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Gym");
            }

            // Propagate any Identity errors (e.g. password complexity) to the view
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }


        #endregion

        #region Login

        [HttpGet]
        [HttpGet]
        public IActionResult Login()
        {
            // If the user is already signed in, redirect to home
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Gym");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Try to find the user by username first, then by email
            var user = await _userManager.FindByNameAsync(model.UserName)
                    ?? await _userManager.FindByEmailAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user,
                model.Password,
                isPersistent: true,   // change to true if you add a "Remember Me" checkbox
                lockoutOnFailure: true);

            if (result.Succeeded)
                return RedirectToAction("Index", "Gym");

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account has been locked out. Please try again later.");
                return View(model);
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(model);
        }
        #endregion

        #region
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
        #endregion
    }

}



