using FeedBackAppA.Interfaces;
using FeedBackAppA.Services;
using NUnit.Framework;

namespace EFeedbackTest
{
    public class FakeEmailService : IEmailService
    {
        public void SendEmail(string toEmail, string subject, string body)
        {
           
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
           
            string toEmail = "recipient@example.com";
            string subject = "Test Subject";
            string body = "Test Body";

         
            _smtpEmailService.SendEmail(toEmail, subject, body);

           
        }
    }
}
