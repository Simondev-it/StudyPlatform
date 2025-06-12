using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Following
{
    public int Id { get; set; }

    public string? Chapter { get; set; }

    public string? Topic { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Follower> Followers { get; set; } = new List<Follower>();

    public virtual User? User { get; set; }
}
