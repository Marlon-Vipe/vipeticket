using System;
using System.Collections.Generic;

namespace Vipe_Tickets.Models;

public partial class Ticket
{
    public int IdTicket { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Status { get; set; }

    public int Priority { get; set; }

    public int CreatedBy { get; set; }

    public int? AssignedTo { get; set; }

    public int? CategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? AssignedToNavigationIdUser { get; set; }

    public int? CategoryIdNavigationIdCategory { get; set; }

    public virtual User? AssignedToNavigationIdUserNavigation { get; set; }

    public virtual Category? CategoryIdNavigationIdCategoryNavigation { get; set; }
}
