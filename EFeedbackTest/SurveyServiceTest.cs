using Microsoft.EntityFrameworkCore;

using NUnit.Framework;
using FeedBackAppA.Contexts;
using FeedBackAppA.Interfaces;
using FeedBackAppA.Models;
using FeedBackAppA.Repositories;
using FeedBackAppA.Services;
using System.Collections.Generic;
using FeedBackAppA.Exceptions;

namespace EFeedbackTest
{
    public class SurveyServiceTest
    {
        private ISurveyRepository surveyRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<FeedBackContext>()
                                .UseInMemoryDatabase("dbTestSurvey")
                                .Options;
            FeedBackContext context = new FeedBackContext(dbOptions);
            surveyRepository = new SurveyRepository(context);
        }

        [Test]
        public void CreateSurvey_ValidSurvey_AddedToRepository()
        {
           
            var surveyService = new SurveyService(surveyRepository);
            var survey = new Survey
            {
                Title = "Sample Survey",

               
                
            };

          
            surveyService.CreateSurvey(survey);

           
            var retrievedSurvey = surveyService.GetSurveyById(survey.Id);
            Assert.IsNotNull(retrievedSurvey);
            Assert.AreEqual(survey.Id, retrievedSurvey.Id);
        }

        [Test]
        public void GetSurveyById_ExistingId_ReturnsSurvey()
        {
           
            var surveyService = new SurveyService(surveyRepository);
            var expectedSurvey = new Survey
            {
                Id = 1,
                Title = "Sample Survey",
               
            };
            surveyService.CreateSurvey(expectedSurvey);

            
            var result = surveyService.GetSurveyById(1);

           
            Assert.AreEqual(expectedSurvey, result);
        }

        [Test]
        public void GetSurveyById_NonExistingId_ThrowsSurveyNotFoundException()
        {
           
            var surveyService = new SurveyService(surveyRepository);

          
            Assert.Throws<SurveyNotFoundException>(() => surveyService.GetSurveyById(999));
        }

        [Test]
        public void GetAllSurveys_RepositoryHasSurveys_ReturnsSurveys()
        {
           
            var surveyService = new SurveyService(surveyRepository);
            var surveysToAdd = new List<Survey>
            {
                new Survey
                {
                    Title = "Survey 1",
                   
                   
                },
                new Survey
                {
                    Title = "Survey 2",
                   
                    
                },
                new Survey
                {
                    Title="Survey 3",
                }
            };

            foreach (var survey in surveysToAdd)
            {
                surveyService.CreateSurvey(survey);
            }

           
            var result = surveyService.GetAllSurveys();

            
            CollectionAssert.AreEquivalent(surveysToAdd, result);
        }
    }
}