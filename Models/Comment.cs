using System;
using System.Collections.Generic;

namespace Vipe_Tickets.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int TicketId { get; set; }

    public string CommentText { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }
}
