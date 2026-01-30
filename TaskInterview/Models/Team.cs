namespace TaskInterview.Models
{
    public class Team
    {
        public int Id { get; set; }   
        public string Name { get; set; }

        public int ManagerId { get; set; }
        public User Manager { get; set; }

        public ICollection<TeamUser> TeamUsers { get; set; }
    }
}
