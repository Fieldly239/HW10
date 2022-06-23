namespace Feedback.Models
{
    public class Feedbacks
    {
        public int Id { get; set; }
        public string FeedbackName { get; set; }
        public string? Description { get; set; }
        //public Applications? Applications { get; set; }
        public int ApplicationId { get; set; }
    }
}
