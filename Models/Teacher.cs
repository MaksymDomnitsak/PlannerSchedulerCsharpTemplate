using System;
using System.Collections.Generic;

namespace PlannerScheduler.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    public virtual User User { get; set; } = null!;
}
