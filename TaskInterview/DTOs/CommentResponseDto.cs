namespace TaskInterview.DTOs
{
    public class CommentResponseDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public int TaskId { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; }
    }
}
