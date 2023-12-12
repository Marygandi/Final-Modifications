namespace FeedBackAppA.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<Question>? Questions { get; set; }
       public int ResponseCount { get; set; }
        //public ICollection<SurveySubmission> SurveySubmissions { get; set; }
        public ICollection<SurveySubmission> SurveySubmissions { get; set; } = new List<SurveySubmission>();

    }
}
