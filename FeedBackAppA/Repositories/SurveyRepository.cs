using FeedBackAppA.Contexts;
using FeedBackAppA.Exceptions;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Migrations;
using FeedBackAppA.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedBackAppA.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly FeedBackContext _dbContext;

        object ISurveyRepository.Survey => throw new NotImplementedException();

        public SurveyRepository(FeedBackContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Survey> GetAll()
        {
            return _dbContext.Surveys.ToList();
        }
        public Survey GetByIdentity(int identity)
        {
            var survey = _dbContext.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefault(s => s.Id == identity);

            if (survey == null)
            {
                throw new SurveyNotFoundException($"Survey with ID {identity} not found.");
            }

            return survey;
        }

        public Survey GetById(int id)
        {
            var survey = _dbContext.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefault(s => s.Id == id);

            if (survey == null)
            {
                throw new SurveyNotFoundException($"Survey with ID {id} not found.");
            }

            return survey;
        }
        public Survey GetByIdWithSubmissions(int id)
        {
            var survey = _dbContext.Surveys
                .Include(s => s.SurveySubmissions)
                .FirstOrDefault(s => s.Id == id);

            if (survey == null)
            {
                throw new SurveyNotFoundException($"Survey with ID {id} not found.");
            }

            return survey;
        }


        public void Add(Survey survey)
        {
            _dbContext.Surveys.Add(survey);
            _dbContext.SaveChanges();
        }
        public List<SurveyReport> GetSurveyReports(int surveyId)
        {
            var reports = _dbContext.SurveyReports
                .Where(report => report.SurveyId == surveyId)
                .ToList();

            return reports;
        }
        public Survey GetSurveyWithSubmissionsAndUsers(int surveyId, int surveySubmissionId)
        {
            var submission = _dbContext.Surveys
                .Where(s => s.Id == surveyId)
                .Include(s => s.SurveySubmissions)
                .ThenInclude(ss => ss.User)
                .FirstOrDefault();
            if (submission == null)
            {
                throw new SurveySubmissionNotFoundException($"Survey submission with ID {surveySubmissionId} not found.");
            }

            return submission;
        }
    }


}






