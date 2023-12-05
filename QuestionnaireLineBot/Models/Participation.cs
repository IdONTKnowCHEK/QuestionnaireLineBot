using System;
using System.Collections.Generic;

namespace QuestionnaireLineBot.Models;

public partial class Participation
{
    public int ParticipationId { get; set; }

    public string? AccountId { get; set; }

    public string? ActivityId { get; set; }

    public DateTime? JoinDate { get; set; }
}
