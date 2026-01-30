namespace TaskInterview.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public ICollection<TaskItem> TasksAssigned { get; set; }
        public ICollection<TaskItem> TasksCreated { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }
    }
}
