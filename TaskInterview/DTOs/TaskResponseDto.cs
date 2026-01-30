public class TaskResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime DueDate { get; set; }

    public int AssignedToUserId { get; set; }
    public string AssignedToUserName { get; set; }

    public int? CreatedByUserId { get; set; }  
}
