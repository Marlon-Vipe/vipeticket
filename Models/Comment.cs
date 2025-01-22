using System;
using System.Collections.Generic;

namespace Vipe_Tickets.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int TicketId { get; set; }

    public int UserId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
