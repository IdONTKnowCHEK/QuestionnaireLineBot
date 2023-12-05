using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Activity
{
    public string ActivityId { get; set; } = null!;

    public string? ActivityName { get; set; }

    public bool? ActivityOpen { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? CreateTime { get; set; }
}
