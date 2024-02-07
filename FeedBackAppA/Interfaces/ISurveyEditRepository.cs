using FeedBackAppA.Models;

namespace FeedBackAppA.Interfaces
{
    public interface ISurveyEditRepository
    {
        Task<IEnumerable<Question>> GetQuestionsForSurveyAsync(int surveyId);
        Task AddQuestionToSurveyAsync(int surveyId, Question question);
        Task UpdateQuestionInSurveyAsync(int surveyId, int questionId, Question question);
        Task DeleteQuestionFromSurveyAsync(int surveyId, int questionId);
        Task DeleteSurveyAsync(int surveyId); // New method for deleting the entire survey
        Task<Question> GetQuestionByIdAsync(int questionId);
    }
}