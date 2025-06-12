using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public DateOnly? UploadDate { get; set; }

    public DateOnly? LastEditDate { get; set; }

    public virtual ICollection<BoughtSubject> BoughtSubjects { get; set; } = new List<BoughtSubject>();

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
}
