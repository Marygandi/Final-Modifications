using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FeedBackAppA.Contexts;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using FeedBackAppA.Models.DTOs;
using FeedBackAppA.Repositories;
using FeedBackAppA.Services;
using System.Text;

namespace EFeedbackTest
{
    public class UserServiceTest
    {
        IRepository<string, User> repository;
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<FeedBackContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            FeedBackContext context = new FeedBackContext(dbOptions);
            repository = new UserRepository(context);

        }

        [Test]
        [TestCase("Test", "test123")]
        

        public void LoginTest(string un, string pass)
        {

            //Arrange
            var appSettings = @"{""SecretKey"": ""Anything will work here this is just for testing""}";
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)));
            var tokenService = new TokenService(configurationBuilder.Build());
            IUserService userService = new UserService(repository, tokenService);
            userService.Register(new UserDTO
            {
                Username = un,
                Password = pass,
                Role = "Admin",
                email = "test@gmail.com"
            });
            //Action
            var resulut = userService.Login(new UserDTO { Username = "Test", Password = "test123", Role = "Admin", email = "test@gmail.com" });
            //Assert
            Assert.AreEqual("Test", resulut.Username);
        }
    }
}