namespace TrickingLibrary.Api.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int TrickId { get; set; }
        public string Video { get; set; }
        public string Description { get; set; }
    }
}