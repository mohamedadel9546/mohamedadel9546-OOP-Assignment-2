using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.AppointmentDesk;

public class IcsCalendarExporter
{
    private readonly BussinesHours bussinesHours=null!;

    public IcsCalendarExporter(BussinesHours bussinesHours)
    {
        this.bussinesHours = bussinesHours;
    }

    public string ToIcs(DateTimeOffset slot, string patientName, string clinician)
    {
        // Calendar interoperability format changes with clients — not opening hours.
        var uid = Guid.NewGuid();
        var end = slot.AddMinutes(bussinesHours.SlotMinutes);
        return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
               $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
    }
}
