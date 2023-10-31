using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class AccountPerson
{
    /// <summary>
    /// 使用者帳號(LOGIN_ID)
    /// </summary>
    public string Account { get; set; } = null!;

    /// <summary>
    /// 使用者名稱
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 使用者所屬單位
    /// </summary>
    public string? Department { get; set; }

    /// <summary>
    /// 單位代碼
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// 使用者電子信箱
    /// </summary>
    public string? Email { get; set; }
}
