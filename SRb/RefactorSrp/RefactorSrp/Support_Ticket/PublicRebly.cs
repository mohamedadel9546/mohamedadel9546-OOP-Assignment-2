using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.SupportTicket;

public class PublicRebly
{
    private readonly Supportticket supportTicket = null!;
    private readonly DeadLIne DeadLIne = null!;

    public PublicRebly(Supportticket supportTicket, DeadLIne deadLIne)
    {
        this.supportTicket = supportTicket;
        DeadLIne = deadLIne;
    }

    public string DraftPublicReply(string agentName)
    {
        // Tone/templates owned by CX — not by SLA engineering.
        var apology = supportTicket.Priority == "P1" ? "We are treating this as a critical incident." : "Thanks for reaching out.";
        return $"Hi,\n{apology}\nTicket {supportTicket.Id} is with {agentName}. Next update before {DeadLIne.SlaDeadline():u}.\n";
    }
}
