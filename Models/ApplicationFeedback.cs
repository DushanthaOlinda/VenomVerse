using System.ComponentModel.DataAnnotations;
using VenomVerseApi.DTO;

namespace VenomVerseApi.Models
{
    public class ApplicationFeedback {

        // public ApplicationFeedback(int userId, string firstName, string lastName, float ratingCount, string ratingFeedback)
        // {
        //     UserId = userId;
        //     FirstName = firstName;
        //     LastName = lastName;
        //     Rating = ratingCount;
        //     Feedback = ratingFeedback;
        // }
        public ApplicationFeedback() { }

        // public int ApplicationFeedbackId { get; set; }
        [Key] public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float Rating { get; set; }
        public string? Feedback { get; set; }

    }

}