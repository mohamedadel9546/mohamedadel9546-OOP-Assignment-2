using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.SupportTicket;

public class InternalReply
{
    private readonly Supportticket supportTicket = null!;
    private readonly DeadLIne DeadLIne = null!;

    public InternalReply(Supportticket supportTicket, DeadLIne deadLIne)
    {
        this.supportTicket = supportTicket;
        DeadLIne = deadLIne;
    }

    public string InternalEscalationBlurb()
    {
        return $"ESCALATE {supportTicket.Id} priority={supportTicket.Priority} breachAt={DeadLIne.SlaDeadline():u} keywords-scanned=yes";
    }
}

