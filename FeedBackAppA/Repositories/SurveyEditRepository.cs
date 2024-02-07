using FeedBackAppA.Contexts;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedBackAppA.Repositories
{
    public class SurveyEditRepository : ISurveyEditRepository
    {
        private readonly FeedBackContext _dbContext;

        public SurveyEditRepository(FeedBackContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Question>> GetQuestionsForSurveyAsync(int surveyId)
        {
            var survey = await _dbContext.Surveys.Include(s => s.Questions).FirstOrDefaultAsync(s => s.Id == surveyId);
            return survey?.Questions;
        }

        public async Task AddQuestionToSurveyAsync(int surveyId, Question question)
        {
            var survey = await _dbContext.Surveys.FindAsync(surveyId);

            if (survey == null)
            {
                // Handle the case when the survey is not found
                // For example, throw an exception, log an error, etc.
                throw new InvalidOperationException($"Survey with ID {surveyId} not found.");
            }

            survey.Questions ??= new List<Question>(); // Ensure Questions is initialized
            survey.Questions.Add(question);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateQuestionInSurveyAsync(int surveyId, int questionId, Question updatedQuestion)
        {
            var survey = await _dbContext.Surveys.Include(s => s.Questions).FirstOrDefaultAsync(s => s.Id == surveyId);

            if (survey == null)
            {
                throw new InvalidOperationException($"Survey with ID {surveyId} not found.");
            }

            var existingQuestion = survey.Questions.FirstOrDefault(q => q.Id == questionId);

            if (existingQuestion == null)
            {
                throw new InvalidOperationException($"Question with ID {questionId} not found in the survey.");
            }

            // Update the properties of the existingQuestion with the new values
            existingQuestion.Text = updatedQuestion.Text;
            existingQuestion.Type = updatedQuestion.Type;
            // Update other properties as needed

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception
                throw;
            }
        }

       /* public async Task DeleteQuestionFromSurveyAsync(int surveyId, int questionId)
        {
            var survey = await _dbContext.Surveys.FindAsync(surveyId);
            var question = await _dbContext.Questions.FindAsync(questionId);

            if (survey != null && question != null)
            {
                survey.Questions.Remove(question);
                await _dbContext.SaveChangesAsync();
            }
        }*/
        public async Task DeleteQuestionFromSurveyAsync(int surveyId, int questionId)
        {
            var survey = await _dbContext.Surveys.FindAsync(surveyId);
            var question = await _dbContext.Questions.FindAsync(questionId);

            if (survey != null && question != null)
            {
                // Delete associated answers first
                var answersToDelete = _dbContext.Answers.Where(a => a.QuestionId == questionId);
                _dbContext.Answers.RemoveRange(answersToDelete);

                // Then delete the question
                _dbContext.Questions.Remove(question);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSurveyAsync(int surveyId)
        {
            var survey = await _dbContext.Surveys.FindAsync(surveyId);

            if (survey != null)
            {
                // Delete all questions associated with the survey
                var questionsToDelete = _dbContext.Questions.Where(q => q.SurveyId == surveyId);
                _dbContext.Questions.RemoveRange(questionsToDelete);

                // Delete all answers associated with the questions of the survey
                var answersToDelete = _dbContext.Answers.Where(a => a.Question.SurveyId == surveyId);
                _dbContext.Answers.RemoveRange(answersToDelete);

                // Delete all question responses associated with the survey submissions of the survey
                var surveySubmissionIds = _dbContext.SurveySubmissions.Where(ss => ss.SurveyId == surveyId).Select(ss => ss.SurveyId);
                var questionResponsesToDelete = _dbContext.QuestionResponses.Where(qr => surveySubmissionIds.Contains(qr.SurveySubmissionId));
                _dbContext.QuestionResponses.RemoveRange(questionResponsesToDelete);

                // Delete the survey itself
                _dbContext.Surveys.Remove(survey);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            // Assuming Questions are stored in a DbSet named Questions in your DbContext
            var question = await _dbContext.Questions.FindAsync(questionId);

            return question;
        }


    }
}
