using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class TopicProgress
{
    public int Id { get; set; }

    public int? Score { get; set; }

    public DateOnly? StartDate { get; set; }

    public int? ProgressId { get; set; }

    public int? TopicId { get; set; }

    public virtual Progress? Progress { get; set; }

    public virtual Topic? Topic { get; set; }
}
