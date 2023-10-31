using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Activity
{
    /// <summary>
    /// 活動編號
    /// </summary>
    public string ActivityId { get; set; } = null!;

    /// <summary>
    /// 活動名稱
    /// </summary>
    public string? ActivityName { get; set; }

    /// <summary>
    /// 是否啟用
    /// </summary>
    public bool Enable { get; set; }

    /// <summary>
    /// 活動起始日期
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// 活動結束日期
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// 建立日期
    /// </summary>
    public DateTime CreateDate { get; set; }
}
