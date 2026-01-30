namespace TaskInterview.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }

        public int AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }

        public int? CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
