using System;
using System.Collections.Generic;

namespace PlannerScheduler.Models;

public partial class Note
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int StudentId { get; set; }

    public int? LessonId { get; set; }

    public string Body { get; set; } = null!;

    public bool? IsFinished { get; set; }

    public virtual Schedule? Lesson { get; set; }

    public virtual Student Student { get; set; } = null!;
}
