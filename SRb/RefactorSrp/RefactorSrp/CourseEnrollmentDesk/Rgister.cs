using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.CourseEnrollmentDesk;

public class Rgister
{
    private readonly HashSet<string> _seated = new(StringComparer.OrdinalIgnoreCase);
    public IReadOnlySet<string> Seated => _seated;
    private readonly List<string> _waitlist = new();
    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }
    public Rgister(string courseCode,int capacity , decimal tuition)
    {
        Capacity = capacity;
        Tuition = tuition;
        CourseCode = courseCode;
    }
    public string Register(string studentEmail)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email");
        var email = studentEmail.Trim();

        if (_seated.Contains(email) || _waitlist.Contains(email))
            return "ALREADY_REGISTERED";

        if (_seated.Count < Capacity)
        {
            _seated.Add(email);
            return "SEATED";
        }

        _waitlist.Add(email);
        return $"WAITLIST:{_waitlist.Count}";
    }

    public int WaitlistPosition(string studentEmail)
    {
        var idx = _waitlist.FindIndex(x => x.Equals(studentEmail, StringComparison.OrdinalIgnoreCase));
        return idx < 0 ? -1 : idx + 1;
    }
    public void PromoteFromWaitlist(int seats)
    {
        // Operational promotion policy mixed with messaging responsibilities above.
        while (seats > 0 && _waitlist.Count > 0 && _seated.Count < Capacity)
        {
            var next = _waitlist[0];
            _waitlist.RemoveAt(0);
            _seated.Add(next);
            seats--;
        }
    }
}
