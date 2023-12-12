namespace FeedBackAppA.Exceptions
{
   
    public class SurveyNotFoundException : Exception
    {
        public SurveyNotFoundException() : base("The requested survey is not available.")
        {
        }

        public SurveyNotFoundException(string message) : base(message)
        {
        }

        public SurveyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
