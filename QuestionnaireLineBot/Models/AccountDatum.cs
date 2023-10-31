using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class AccountDatum
{
    /// <summary>
    /// 帳號
    /// </summary>
    public string Account { get; set; } = null!;

    /// <summary>
    /// 活動編號
    /// </summary>
    public string ActivityId { get; set; } = null!;

    /// <summary>
    /// 問卷填寫次數
    /// </summary>
    public int? AnswerTime { get; set; }

    /// <summary>
    /// 兌獎次數
    /// </summary>
    public int? Prize { get; set; }

    /// <summary>
    /// 滿意度填寫次數
    /// </summary>
    public int? Satisfaction { get; set; }
}
