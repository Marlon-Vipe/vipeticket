using System;
using System.Collections.Generic;

namespace Vipe_Tickets.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string Description { get; set; } = null!;
}
