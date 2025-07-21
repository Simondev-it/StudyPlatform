namespace StudyPlatformAPI.DTOs.User
{
    public class UpdatePasswordRequest
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int? CuratorId { get; set; }
        public string? Email { get; set; }
        public int? Point { get; set; }
        public DateOnly? JoinedDate { get; set; }
        public int? DayStreak { get; set; }
        public int? HighestDayStreak { get; set; }
        public string? Image { get; set; }
        public DateOnly? LastOnline { get; set; }
        public string? Type { get; set; }
    }
}
