using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlatform.Models;

public class ChapterProgress
{
    public int Id { get; set; }
    public int Score { get; set; }
    public DateTime? StartDate { get; set; }
    public string Note { get; set; }
    public int UserId { get; set; }
    public int ChapterId { get; set; }
    public virtual Chapter Chapter { get; set; }
    public virtual User User { get; set; }
}
