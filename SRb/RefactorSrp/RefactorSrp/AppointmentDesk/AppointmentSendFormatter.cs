using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.AppointmentDesk;

public class AppointmentSendFormatter
{

    public string SmsReminder(DateTimeOffset slot, string clinicPhone)
    {
        // Messaging channel copy — fourth concern hiding in the "scheduler".
        return $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
    }
}
