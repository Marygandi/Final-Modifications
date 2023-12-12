using System.ComponentModel.DataAnnotations;

namespace FeedBackAppA.Models
{
    public class User

    {
        [Key]
        public string? Username { get; set; }
        public String? email { get; set; }

        public byte[]? Password { get; set; }
        public string? Role { get; set; }
        public byte[]? Key { get; set; }
        public ICollection<SurveySubmission> SurveySubmissions { get; set; }

    }
}