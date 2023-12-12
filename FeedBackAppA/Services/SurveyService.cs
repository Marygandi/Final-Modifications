using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;

namespace FeedBackAppA.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public void CreateSurvey(Survey survey)
        {
            //survey.ResponseCount++;
            _surveyRepository.Add(survey);
        }

        public Survey GetSurveyByIdentity(int identity)
        {
            return _surveyRepository.GetByIdentity(identity);
        }
        public Survey GetSurveyById(int id)
        {
            // Eager load SurveySubmissions
            return _surveyRepository.GetByIdWithSubmissions(id);
        }
        // Other service methods...
        public IEnumerable<Survey> GetAllSurveys()
        {
            return _surveyRepository.GetAll();
        }
       
    }
}
