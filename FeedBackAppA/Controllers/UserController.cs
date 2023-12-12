using FeedBackAppA.Models.DTOs;
using FeedBackAppA.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models.DTOs;
using FeedBackAppA.Models.DTOs;

namespace FeedBackAppA.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewModel viewModel)
        {
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DbUpdateException exp)
            {
                ViewBag.Message = "User name already exits";
            }
            catch (Exception)
            {
                ViewBag.Message = "Invalid data. Coudld not register";
                throw;
            }
            //ViewData["Message"] = "Invalid data. Coudld not register";

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                TempData.Add("username", userDTO.Username);
                return RedirectToAction("Index", "Home");
            }
            ViewData["Message"] = "Invalid username or password";
            return View();
        }
    }
}