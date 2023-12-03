using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string? ActivityId { get; set; }

    public string? QuestionContent { get; set; }

    public int? Answer { get; set; }

    public virtual Activity? Activity { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
}
