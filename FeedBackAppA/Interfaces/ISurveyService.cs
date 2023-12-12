using FeedBackAppA.Models;

namespace FeedBackAppA.Interfaces
{
    public interface ISurveyService
    {
        void CreateSurvey(Survey survey);
        Survey GetSurveyById(int id);
        Survey GetSurveyByIdentity(int identity);
        IEnumerable<Survey> GetAllSurveys();
        // Other service methods...
    }
}
