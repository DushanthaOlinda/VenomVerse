using VenomVerseApi.DTO;

namespace VenomVerseApi.Models
{
    public class ApplicationFeedback {

        public ApplicationFeedback(long userId, string firstName, string lastName, float rating, string feedback)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Rating = rating;
            Feedback = feedback;
        }

        public long ApplicationFeedbackId { get; set; }
        public long UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float Rating { get; set; }
        public string? Feedback { get; set; }

    }

}