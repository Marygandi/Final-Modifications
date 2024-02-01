using FeedBackAppA.Exceptions;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using FeedBackAppA.Repositories;
using FeedBackAppA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace FeedBackAppA.Controllers
{
    [EnableCors("reactApp")]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        private readonly ILogger<SurveyController> _logger;
        private readonly IEmailService _emailService;

        public SurveyController(ISurveyService surveyService, ILogger<SurveyController> logger, IEmailService emailService)
        {
            _surveyService = surveyService;
            _logger = logger;
            _emailService = emailService;

        }
        [HttpGet("survey1/{identity}")]
        public IActionResult GetSurveys(int identity)
        {
            var survey = _surveyService.GetSurveyByIdentity(identity);
            if (survey == null)
                return NotFound();

   
            return Ok(survey);
        }

        [HttpGet("survey/{id}")]
        public IActionResult GetSurvey(int id)
        {
            var survey = _surveyService.GetSurveyById(id);
            if (survey == null)
                return NotFound();

            return Ok(survey);
        }
        

        [HttpPost]
        public IActionResult CreateSurvey([FromBody] Survey survey)
        {
            _surveyService.CreateSurvey(survey);
            return CreatedAtAction(nameof(GetSurvey), new { id = survey.Id }, survey);
        }


      
        [HttpGet]
        public IActionResult GetAllSurveys()
        {
            var surveys = _surveyService.GetAllSurveys();
            return Ok(surveys);
        }
       
        
        
        [HttpGet("{id}/report")]
       
        public IActionResult GetSurveyReport(int id)
        {
            var survey = _surveyService.GetSurveyById(id);

            if (survey == null)
            {
                return NotFound("Survey not found");
            }

            var report = new SurveyReport(survey); 

            return Ok(report);
        }
        
         [HttpPost("SendSurveyByEmail")]
         public IActionResult SendSurveyByEmail([FromBody] SurveyEmailRequest emailRequest)
         {
             try
             {
                 var survey = _surveyService.GetSurveyByIdentity(emailRequest.SurveyNumber);

                 if (survey == null)
                 {
                     return NotFound("Survey not found");
                 }

                string surveyLink = $"http://localhost:3000/surveys/"+emailRequest.SurveyNumber;
              
                string emailBody = $"Dear user,\n\nPlease take the survey by following this link:\n{surveyLink}";
            
                 _emailService.SendEmail(emailRequest.UserEmail, "Survey Invitation", emailBody);

                 return Ok("Survey sent successfully via email");
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
                 return StatusCode(500, "Internal Server Error");
             }
         }
        
    }



}
