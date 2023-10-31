using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class QuestionBank
{
    /// <summary>
    /// 題目編號
    /// </summary>
    public int QuestionId { get; set; }

    /// <summary>
    /// 活動編號
    /// </summary>
    public string ActivityId { get; set; } = null!;

    /// <summary>
    /// 題目
    /// </summary>
    public string? Question { get; set; }

    /// <summary>
    /// 解答
    /// </summary>
    public int? Answer { get; set; }
}
