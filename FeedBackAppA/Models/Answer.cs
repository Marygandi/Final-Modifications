namespace FeedBackAppA.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? QuestionId { get; set; }

        // Navigation property
        public Question? Question { get; set; }
    }
}
