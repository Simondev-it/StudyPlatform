using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Accomplishment
{
    public int Id { get; set; }

    public int Progress { get; set; }

    public DateOnly? AchieveDate { get; set; }

    public string? Status { get; set; }

    public int AchievementId { get; set; }

    public int UserId { get; set; }

    public virtual Achievement? Achievement { get; set; }

    public virtual User? User { get; set; }
}
