using System;
using System.Collections.Generic;

namespace Vipe_Tickets.Models;

public partial class TicketLog
{
    public int IdTicketLog { get; set; }

    public int TicketId { get; set; }

    public int ChangedBy { get; set; }

    public string Field { get; set; } = null!;

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public DateTime? ChangedAt { get; set; }
}
