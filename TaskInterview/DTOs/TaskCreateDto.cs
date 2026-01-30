namespace TaskInterview.DTOs
{
    public class TaskDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Priority { get; set; } = "Medium";
        public DateTime DueDate { get; set; }
        public int AssignedToUserId { get; set; }
    }
}
