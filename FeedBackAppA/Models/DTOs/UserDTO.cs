using System.ComponentModel.DataAnnotations;

namespace FeedBackAppA.Models.DTOs
{
    public class UserDTO
    {

        [Required(ErrorMessage = "Username cannot be empty")]
        public string? Username { get; set; }
        //[Required(ErrorMessage = "enter valid email")]
        public string? email { get; set; }

        public string? Role { get; set; }
        public string? Token { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string? Password { get; set; }
    }
}