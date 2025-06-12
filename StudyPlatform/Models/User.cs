using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class User
{
    public int Id { get; set; }

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

    public virtual ICollection<Accomplishment> Accomplishments { get; set; } = new List<Accomplishment>();

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<BoughtSubject> BoughtSubjects { get; set; } = new List<BoughtSubject>();

    public virtual ICollection<Follower> Followers { get; set; } = new List<Follower>();

    public virtual ICollection<Following> Followings { get; set; } = new List<Following>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
