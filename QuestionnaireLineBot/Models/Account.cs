using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Account
{
    public string AccountId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public int? DepartmentId { get; set; }

    public int? SurveyCount { get; set; }

    public int? SatisfactionAnswerCount { get; set; }

    public int? PrizeRedemptionCount { get; set; }
}
