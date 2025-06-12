using System;
using System.Collections.Generic;

namespace StudyPlatform.Models;

public partial class Follower
{
    public int Id { get; set; }

    public int? FollowerId { get; set; }

    public DateOnly? FollowDate { get; set; }

    public int? FollowingId { get; set; }

    public int? UserId { get; set; }

    public virtual Following? Following { get; set; }

    public virtual User? User { get; set; }
}
