using System;
using System.Collections.Generic;

namespace PlannerScheduler.Models;

public partial class Student
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Group { get; set; }

    public virtual Group GroupNavigation { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; } = new List<Note>();

    public virtual User User { get; set; } = null!;
}
