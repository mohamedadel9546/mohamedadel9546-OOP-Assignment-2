using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern;

public class Builder
{
    public sealed class CourseRegistration
    {
        public string StudentEmail { get; }
        public string CourseCode { get; }
        public string AccessMode { get; }
        public string? GroupCode { get; }
        public string? DiscountCode { get; }
        public bool SendWhatsApp { get; }
        public bool SendEmailWelcome { get; }
        public string? MentorNote { get; }
        public DateOnly? PreferredStart { get; }

        public CourseRegistration(
            string studentEmail,
            string courseCode,
            string accessMode,
            string? groupCode,
            string? discountCode,
            bool sendWhatsApp,
            bool sendEmailWelcome,
            string? mentorNote,
            DateOnly? preferredStart)
        {
            if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
            if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

            if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
                throw new InvalidOperationException("LiveGroup requires GroupCode");
            if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
                throw new InvalidOperationException("VideosOnly cannot have GroupCode");

            StudentEmail = studentEmail;
            CourseCode = courseCode;
            AccessMode = accessMode;
            GroupCode = groupCode;
            DiscountCode = discountCode;
            SendWhatsApp = sendWhatsApp;
            SendEmailWelcome = sendEmailWelcome;
            MentorNote = mentorNote;
            PreferredStart = preferredStart;
        }

        public override string ToString()
            => $"{StudentEmail} → {CourseCode} [{AccessMode}] group={GroupCode ?? "-"} discount={DiscountCode ?? "-"} wa={SendWhatsApp} mail={SendEmailWelcome}";
    }

    public static class RegistrationCallSites
    {
        public static CourseRegistration CreateLiveStudentUgly()
        {
            return new CourseRegistrationBuilder("sara@mail.com", "SEF-101", "LiveGroup")
                .WithGroupCode("G1")
                .WithDiscountCode("EARLY10")
                .WithSendWhatsApp(true)
                .WithSendEmailWelcome(true)
                .WithMentorNote("Needs evening slot")
                .WithStart(new DateOnly(2026, 10, 1))
                .Build();
        }

        public static CourseRegistration CreateVideosOnlyUgly()
        {
            return new CourseRegistrationBuilder("ali@mail.com", "SEF-101", "VideosOnly")
               .WithSendEmailWelcome(true)
               .Build();  
        }
    }

    public sealed class CourseRegistrationBuilder
    {
        public CourseRegistrationBuilder(string studentEmail, string courseCode, string accessMode)
        {
            StudentEmail = studentEmail;
            CourseCode = courseCode;
            AccessMode = accessMode;
        }
        public string StudentEmail { get; }
        public string CourseCode { get; }
        public string AccessMode { get; }

        public DateOnly? PreferredStart { get; private set;}
        public string? GroupCode { get; private set; }
        public string? DiscountCode { get; private set; }
        public bool SendWhatsApp { get; private set; } = false;
        public bool SendEmailWelcome { get; private set; } = false;
        public string? MentorNote { get; private set; }

        public CourseRegistrationBuilder WithStart(DateOnly? preferredStart)
        {
            PreferredStart = preferredStart;
            return this;
        }
        public CourseRegistrationBuilder WithGroupCode(string? groupCode)
        {
            GroupCode = groupCode;
            return this;
        }
        public CourseRegistrationBuilder WithDiscountCode(string? Discountcode)
        {
            DiscountCode = Discountcode;
            return this;
        }
        public CourseRegistrationBuilder WithSendWhatsApp(bool SendwhatsApp)
        {
            SendWhatsApp = SendwhatsApp;
            return this;
        }
        public CourseRegistrationBuilder WithSendEmailWelcome(bool SendemailWelcome)
        {
            SendEmailWelcome = SendemailWelcome;
            return this;
        }
        public CourseRegistrationBuilder WithMentorNote(string? Mentornote)
        {
            MentorNote = Mentornote;
            return this;
        }

        public CourseRegistration Build()
        {
            return new CourseRegistration(StudentEmail,CourseCode,AccessMode,GroupCode,DiscountCode,SendWhatsApp,
                SendEmailWelcome,MentorNote,PreferredStart);
        }

    }
}
