using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Topic
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public string? Name { get; set; }

    public int? ChapterId { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<TopicProgress> TopicProgresses { get; set; } = new List<TopicProgress>();
}
