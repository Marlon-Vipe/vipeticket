using System;
using System.Collections.Generic;

namespace Vipe_Tickets.Models;

public partial class Priority
{
    public int IdPriority { get; set; }

    public string Description { get; set; } = null!;
}
