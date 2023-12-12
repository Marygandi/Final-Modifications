using FeedBackAppA.Models;

namespace FeedBackAppA.Interfaces
{
    public interface ISurveyRepository
    {
        object Survey { get; }
        IEnumerable<Survey> GetAll();

        Survey GetById(int id);
        Survey GetByIdentity(int identity);
        void Add(Survey survey);
        Survey GetByIdWithSubmissions(int id);

    }
}
