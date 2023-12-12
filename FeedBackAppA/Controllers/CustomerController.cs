using FeedBackAppA.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using Microsoft.AspNetCore.Cors;

namespace FeedBackAppA.Controllers
{
    [EnableCors("reactApp")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public ActionResult Register(UserDTO viewModel)
        {
           
            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                
                if (user != null)
                {
                    return Ok(user);
                }
            }
           
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return BadRequest(message);

        }

        [HttpPost]
        [Route("Login")]//attribute based routing
        public ActionResult Login(UserDTO userDTO)
        {
            var result = _userService.Login(userDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return Unauthorized("Invalid username or password");
        }
    }
}