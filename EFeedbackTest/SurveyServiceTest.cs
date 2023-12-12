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
            // Arrange
            var surveyService = new SurveyService(surveyRepository);
            var survey = new Survey
            {
                Title = "Sample Survey",

               
                // Add other properties initialization
            };

            // Act
            surveyService.CreateSurvey(survey);

            // Assert
            var retrievedSurvey = surveyService.GetSurveyById(survey.Id);
            Assert.IsNotNull(retrievedSurvey);
            Assert.AreEqual(survey.Id, retrievedSurvey.Id);
        }

        [Test]
        public void GetSurveyById_ExistingId_ReturnsSurvey()
        {
            // Arrange
            var surveyService = new SurveyService(surveyRepository);
            var expectedSurvey = new Survey
            {
                Id = 1,
                Title = "Sample Survey",
               
                // Add other properties initialization
            };
            surveyService.CreateSurvey(expectedSurvey);

            // Act
            var result = surveyService.GetSurveyById(1);

            // Assert
            Assert.AreEqual(expectedSurvey, result);
        }

        [Test]
        public void GetSurveyById_NonExistingId_ThrowsSurveyNotFoundException()
        {
            // Arrange
            var surveyService = new SurveyService(surveyRepository);

            // Act and Assert
            Assert.Throws<SurveyNotFoundException>(() => surveyService.GetSurveyById(999));
        }

        [Test]
        public void GetAllSurveys_RepositoryHasSurveys_ReturnsSurveys()
        {
            // Arrange
            var surveyService = new SurveyService(surveyRepository);
            var surveysToAdd = new List<Survey>
            {
                new Survey
                {
                    Title = "Survey 1",
                   
                    // Add other properties initialization
                },
                new Survey
                {
                    Title = "Survey 2",
                   
                    // Add other properties initialization
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

            // Act
            var result = surveyService.GetAllSurveys();

            // Assert
            CollectionAssert.AreEquivalent(surveysToAdd, result);
        }
    }
}