using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class SatisfactionQuestion
{
    public int SatisfactionQuestionId { get; set; }

    public string? ActivityId { get; set; }

    public string? SatisfactionQuestionContent { get; set; }

    public virtual Activity? Activity { get; set; }

    public virtual ICollection<SatisfactionAnswer> SatisfactionAnswers { get; set; } = new List<SatisfactionAnswer>();
}
