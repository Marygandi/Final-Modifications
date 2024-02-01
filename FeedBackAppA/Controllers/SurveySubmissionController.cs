using FeedBackAppA.Contexts;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Migrations;
using FeedBackAppA.Models;
using FeedBackAppA.Models.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FeedBackAppA.Controllers
{
    [EnableCors("reactApp")]
    [Route("api/[controller]")]
    [ApiController]
    public class SurveySubmissionController : ControllerBase
    {

        private readonly FeedBackContext _context;
        private readonly ILogger<SurveySubmissionController> _logger;

        public SurveySubmissionController(FeedBackContext context,ILogger<SurveySubmissionController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SubmitSurvey([FromBody] SurveySubmission submission)
        {
            try
            {
                _context.SurveySubmissions.Add(submission);
                _context.SaveChanges();
                _logger.LogInformation("SurveySubmission listed");
                var survey = _context.Surveys.Find(submission.SurveyId);
                if (survey != null)
                {
                    survey.ResponseCount++;
                    _context.SaveChanges();
                }

                return Ok(submission);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                _logger.LogError("No surveys available in the collection");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
