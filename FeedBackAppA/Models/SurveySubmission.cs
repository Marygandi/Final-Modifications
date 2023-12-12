using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBackAppA.Models
{
    public class SurveySubmission
    {
        public int SurveySubmissionId { get; set; }
        public string Username { get; set; }
        public int SurveyId { get; set; }
        public Survey? Survey { get; set; }
        //[ForeignKey("SurveyId")]
        //public Survey Survey { get; set; }

        //public int ResponseCount { get; set; }
        public ICollection<QuestionResponse> QuestionResponses { get; set; }

        // ... existing properties ...

        // Add a navigation property for the associated User
       public User? User { get; set; }

        // ... other properties and methods ...
    }
}