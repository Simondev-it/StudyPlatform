using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Chapter
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public string? Name { get; set; }

    public int? SubjectId { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
