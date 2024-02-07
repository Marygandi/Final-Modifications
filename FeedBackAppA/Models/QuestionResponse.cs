namespace FeedBackAppA.Models
{
    public class QuestionResponse
    {
        public int QuestionResponseId { get; set; }
        public int QuestionId { get; set; }
       // public Question Question { get; set; }
        public string AnswerId { get; set; }
       // public Answer Answer { get; set; }
       public int SurveySubmissionId { get; set; }
        public SurveySubmission SurveySubmission { get; set; }
    }
}
