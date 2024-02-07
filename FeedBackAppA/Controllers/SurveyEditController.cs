using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedBackAppA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyEditController : ControllerBase
    {
        private readonly ISurveyEditRepository _repository;

        public SurveyEditController(ISurveyEditRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{surveyId}/Questions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsForSurvey(int surveyId)
        {
            var questions = await _repository.GetQuestionsForSurveyAsync(surveyId);
            return Ok(questions);
        }

        [HttpPost("{surveyId}/Questions")]
        public async Task<ActionResult<Question>> AddQuestionToSurvey(int surveyId, Question question)
        {
            await _repository.AddQuestionToSurveyAsync(surveyId, question);
            return CreatedAtAction("GetQuestionsForSurvey", new { surveyId }, question);
        }

        [HttpPut("{surveyId}/Questions/{questionId}")]
        public async Task<ActionResult<Question>> UpdateQuestionInSurvey(int surveyId, int questionId, Question question)
        {
            try
            {
                await _repository.UpdateQuestionInSurveyAsync(surveyId, questionId, question);
                // Fetch the updated question from the repository
                var updatedQuestion = await _repository.GetQuestionByIdAsync(questionId);
                return Ok(updatedQuestion);
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{surveyId}/Questions/{questionId}")]
        public async Task<ActionResult<Question>> DeleteQuestionFromSurvey(int surveyId, int questionId)
        {
            try
            {
                await _repository.DeleteQuestionFromSurveyAsync(surveyId, questionId);
                // Return a custom response indicating the deleted question
                return Ok(new { Message = "Question deleted successfully", DeletedQuestionId = questionId });
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{surveyId}")]
        public async Task<ActionResult<Survey>> DeleteSurvey(int surveyId)
        {
            try
            {
                await _repository.DeleteSurveyAsync(surveyId);
                // Return a custom response indicating the deleted survey
                return Ok(new { Message = "Survey deleted successfully", DeletedSurveyId = surveyId });
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // Similar methods for Answers
    }
}
