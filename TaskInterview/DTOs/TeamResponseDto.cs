namespace TaskInterview.DTOs
{
    public class TeamResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }
        public string ManagerName { get; set; }

        public List<TeamUserDto> Users { get; set; }
    }

    public class TeamUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

}
