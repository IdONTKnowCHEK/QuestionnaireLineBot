using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Satisfaction
{
    /// <summary>
    /// 滿意度問題
    /// </summary>
    public string SatisfactionQuestion { get; set; } = null!;

    /// <summary>
    /// 活動編號
    /// </summary>
    public string? ActivityId { get; set; }
}
