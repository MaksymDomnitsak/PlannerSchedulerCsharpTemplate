using System;
using System.Collections.Generic;

namespace PlannerScheduler.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    public virtual Student? Student { get; set; }
}
