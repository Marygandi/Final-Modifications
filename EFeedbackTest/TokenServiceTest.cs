/*using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using FeedBackAppA.Models.DTOs;
using FeedBackAppA.Services;

namespace EFeedbackTest
{
    public class TokenServiceTest
    {
        private IConfiguration configuration;

        [SetUp]
        public void Setup()
        {
            // Set up the configuration using an in-memory configuration
            configuration = new ConfigurationBuilder()
                .AddInMemoryCollection()  // You can add any necessary configuration here
                .Build();
        }

        [Test]
        public void GetToken_ValidUser_ReturnsToken()
        {
            // Arrange
            var tokenService = new TokenService(configuration); // Pass the configuration
            var user = new UserDTO { email = "test@example.com", Role = "user" };

            // Act
            var token = tokenService.GetToken(user);

            // Assert
            Assert.IsNotNull(token);
            // Add additional assertions for the generated token if needed
        }
    }
}
*/