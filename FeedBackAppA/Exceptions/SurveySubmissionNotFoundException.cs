namespace FeedBackAppA.Exceptions

{
    public class SurveySubmissionNotFoundException : Exception
    {
        public SurveySubmissionNotFoundException() : base("Survey submission not found.")
        {
        }

        public SurveySubmissionNotFoundException(string message) : base(message)
        {
        }

        public SurveySubmissionNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}