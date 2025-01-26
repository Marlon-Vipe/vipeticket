using System;
using System.Collections.Generic;

namespace Vipe_Tickets.Models;

public partial class TicketHistory
{
    public int HistoryId { get; set; }

    public int TicketId { get; set; }

    public int StatusId { get; set; }

    public int ChangedBy { get; set; }

    public DateTime? ChangedAt { get; set; }

    public string? Notes { get; set; }
}
