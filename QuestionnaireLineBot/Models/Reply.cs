using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Reply
{
    /// <summary>
    /// 答卷流水號
    /// </summary>
    public string TestId { get; set; } = null!;

    /// <summary>
    /// 帳號
    /// </summary>
    public string? Account { get; set; }

    /// <summary>
    /// 活動編號
    /// </summary>
    public string? ActivityId { get; set; }

    /// <summary>
    /// 分數
    /// </summary>
    public int? Score { get; set; }

    /// <summary>
    /// 考卷回答送出時間
    /// </summary>
    public DateTime? TestSendTime { get; set; }
}
