
using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.SupportTicket;

public class DeadLIne
{
    private readonly Supportticket supportTicket = null!;

    public DeadLIne(Supportticket supportTicket)
    {
        this.supportTicket = supportTicket;
    }

    public DateTimeOffset SlaDeadline()
    {
        // Operational SLA policy — different stakeholders than reply wording.
        var hours = supportTicket.Priority switch
        {
            "P1" => 4,
            "P2" => 24,
            _ => 72
        };
        return supportTicket.OpenedAt.AddHours(hours);
    }

    public bool IsBreached(DateTimeOffset now) => now > SlaDeadline();
}
