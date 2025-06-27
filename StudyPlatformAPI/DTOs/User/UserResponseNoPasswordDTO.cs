namespace StudyPlatformAPI.DTOs.User
{
    public class UserResponseNoPasswordDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }

        public string Role { get; set; }

        public int? CuratorId { get; set; }

        public string Email { get; set; }

        public int Point { get; set; }
    }
}
