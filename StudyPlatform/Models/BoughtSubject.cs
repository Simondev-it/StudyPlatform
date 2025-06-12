using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class BoughtSubject
{
    public int Id { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public string? Feedback { get; set; }

    public int? SubjectId { get; set; }

    public int? UserId { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual User? User { get; set; }
}
