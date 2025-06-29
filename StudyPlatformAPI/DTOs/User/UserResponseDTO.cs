namespace StudyPlatformAPI.DTOs.User
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public int? CuratorId { get; set; }

        public string Email { get; set; }

        public int Point { get; set; }
        public DateOnly? JoinedDate { get; set; }

        public int DayStreak { get; set; }

        public int HighestDayStreak { get; set; }
    }
}
