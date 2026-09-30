using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.SupportTicket;

public class Supportticket
{
    public string Id { get; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public DateTimeOffset OpenedAt { get; }
    public string Priority { get; private set; } = "P3";
    private readonly CalculatePoriority CalculatePoriority = null!;
    public Supportticket(string id, string subject, string body, DateTimeOffset openedAt, CalculatePoriority calculatePoriority)
    {
        Id = id;
        Subject = subject;
        Body = body;
        OpenedAt = openedAt;
        CalculatePoriority = calculatePoriority;
        CalculatePoriority.EvaluatePriority(Subject, Body);
    }

    public void AppendCustomerMessage(string text)
    {
        Body += "\n---\n" + text;
        CalculatePoriority.EvaluatePriority(Subject,Body);
    }
   

    public void AddPoriorety(string priority)
    {
        Priority = priority;
    }
}
