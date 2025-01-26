using System;
using System.Collections.Generic;

namespace Vipe_Tickets.Models;

public partial class Priority
{
    public int PriorityId { get; set; }

    public string PriorityName { get; set; } = null!;
}
