using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Question
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public string? Type { get; set; }

    public string? QuestionText { get; set; }

    public string? CorrectAnswer { get; set; }

    public string? OtherAnswer { get; set; }

    public string? Explanation { get; set; }

    public string? Note { get; set; }

    public int? TopicId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Topic? Topic { get; set; }
}
