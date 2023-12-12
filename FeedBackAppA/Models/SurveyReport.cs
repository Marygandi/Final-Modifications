using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBackAppA.Models
{
    public class SurveyReport
    {
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public int RespondentCount { get; set; }
        public string Username { get; set; }
        public SurveyReport()
        {
        }

            // Constructor to initialize from a Survey object
            public SurveyReport(Survey survey)
        {
            if (survey != null)
            {
                SurveyId = survey.Id;
                SurveyTitle = survey.Title ?? "";

                // Assuming there is at least one SurveySubmission
                var firstSubmission = survey.SurveySubmissions.FirstOrDefault();

                if (firstSubmission != null)
                {
                    RespondentCount = survey.SurveySubmissions.Count;
                    if (RespondentCount > 0)
                    {
                        // Concatenate usernames if there are multiple submissions
                        Username = string.Join(", ", survey.SurveySubmissions.Select(firstsubmission => firstsubmission.Username));
                    }
                    // Username = firstSubmission.Username;
                }
                else
                {
                    // Handle the case where there are no submissions
                    RespondentCount = 0;
                    Username = "No submissions";
                }
            }
        }
    }
}
