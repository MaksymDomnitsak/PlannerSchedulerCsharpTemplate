using System;
using System.Collections.Generic;

namespace PlannerScheduler.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public int? SubjectId { get; set; }

    public int TeacherId { get; set; }

    public int Group { get; set; }

    public int DayOfWeek { get; set; }

    public bool IsEvenWeek { get; set; }

    public int LessonOrder { get; set; }

    public int TypeOfLesson { get; set; }

    public bool IsOnline { get; set; }

    public virtual Group GroupNavigation { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; } = new List<Note>();

    public virtual Subject? Subject { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;
}
