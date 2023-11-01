using VenomVerseApi.DTO;

namespace VenomVerseApi.Models
{
    public class ApplicationFeedback {

        public ApplicationFeedback(long userId, string firstName, string lastName, float ratingCount, string ratingFeedback)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Rating = ratingCount;
            Feedback = ratingFeedback;
        }

        public long ApplicationFeedbackId { get; set; }
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float Rating { get; set; }
        public string? Feedback { get; set; }

    }

}