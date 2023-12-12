using FeedBackAppA.Interfaces;
using FeedBackAppA.Services;
using NUnit.Framework;

namespace EFeedbackTest
{
    public class FakeEmailService : IEmailService
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
            // Your fake implementation or assertions can go here
        }
    }

    [TestFixture]
    public class SmtpEmailServiceTests
    {
        private SmtpEmailService _smtpEmailService;
        private FakeEmailService _fakeEmailService;

        [SetUp]
        public void Setup()
        {
            _fakeEmailService = new FakeEmailService();
            _smtpEmailService = new SmtpEmailService();
        }

        [Test]
        public void SendEmail_ValidParameters_SuccessfullySent()
        {
            // Arrange
            string toEmail = "recipient@example.com";
            string subject = "Test Subject";
            string body = "Test Body";

            // Act
            _smtpEmailService.SendEmail(toEmail, subject, body);

            // Assert
            // You can add assertions here based on your specific requirements.
            // For example, check if the fake implementation was called with the correct parameters.

            // Example assertion:
            // Assert.AreEqual(expectedValue, actualValue);

            // Alternatively, you can inspect the state of the fake implementation after the method call.

            // Example:
            // Assert.IsTrue(_fakeEmailService.SomeProperty == expectedValue);
        }
    }
}
