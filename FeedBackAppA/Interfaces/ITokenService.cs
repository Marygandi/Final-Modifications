using FeedBackAppA.Models.DTOs;

namespace FeedBackAppA.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}