using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public string? Answer { get; set; }

    public DateOnly? CommentDate { get; set; }

    public int? QuestionId { get; set; }

    public virtual Question? Question { get; set; }
}
