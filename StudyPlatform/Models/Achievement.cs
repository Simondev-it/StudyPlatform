using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Achievement
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Accomplishment> Accomplishments { get; set; } = new List<Accomplishment>();

    public virtual User? User { get; set; }
}
