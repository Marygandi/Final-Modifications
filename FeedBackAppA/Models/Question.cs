namespace FeedBackAppA.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public String? Type { get; set; }
        public int SurveyId { get; set; }
        public Survey? Survey { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}
