

using FeedBackAppA.Models.DTOs;

namespace FeedBackAppA.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserDTO userDTO);
    }
}