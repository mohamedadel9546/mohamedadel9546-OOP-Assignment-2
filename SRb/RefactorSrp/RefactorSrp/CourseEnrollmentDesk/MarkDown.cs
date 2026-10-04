using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.CourseEnrollmentDesk
{
    public class MarkDown
    {
        private readonly Rgister rgister = null!;

        public MarkDown(Rgister rgister)
        {
            this.rgister = rgister;
        }

        public string WelcomePacketMarkdown(string studentEmail, string studentName)
        {
            // Content design changes with academy marketing — not with seat algorithms.
            var status = rgister.Seated.Contains(studentEmail) ? "confirmed seat" : $"waitlist #{rgister.WaitlistPosition(studentEmail)}";
            return $"# Welcome to {rgister.CourseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
                   $"Bring a laptop. Discord onboarding link: https://example.invalid/{rgister.CourseCode.ToLowerInvariant()}\n";
        }
    }
}
