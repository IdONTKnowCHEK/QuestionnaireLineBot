using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class PrizeRedemption
{
    public int PrizeRedemptionId { get; set; }

    public int? PrizeId { get; set; }

    public string? AccountId { get; set; }

    public string? ActivityId { get; set; }

    public string? RedemptionName { get; set; }

    public DateTime? RedemptionDate { get; set; }
}
