using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class SatisfactionResponse
{
    public int ResponseId { get; set; }

    public string? AccountId { get; set; }

    public string? ActivityId { get; set; }

    public DateTime? SubmissionTime { get; set; }

    public virtual Activity? Activity { get; set; }
}
