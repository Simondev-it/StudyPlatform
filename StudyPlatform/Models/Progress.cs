using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Progress
{
    public int Id { get; set; }

    public string? Chapter { get; set; }

    public string? Topic { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<TopicProgress> TopicProgresses { get; set; } = new List<TopicProgress>();

    public virtual User? User { get; set; }
}
