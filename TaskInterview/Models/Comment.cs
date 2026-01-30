namespace TaskInterview.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public int TaskId { get; set; }
        public TaskItem Task { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
    }

}
