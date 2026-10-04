using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.AppointmentDesk;

public class AppointmentSchedular
{
    private readonly HashSet<DateTimeOffset> _booked = new();
    private readonly BussinesHours bussinesHours=null!;

    public AppointmentSchedular(BussinesHours bussinesHours)
    {
        this.bussinesHours = bussinesHours;
    }
    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
    {
        var cursor = Align(from);
        var end = from.AddHours(searchHours);
        while (cursor < end)
        {
            if (bussinesHours.IsWithinBusinessHours(cursor) && !_booked.Contains(cursor))
                return cursor;
            cursor = cursor.AddMinutes(bussinesHours.SlotMinutes);
        }
        return null;
    }

    public bool TryBook(DateTimeOffset slot)
    {
        if (!bussinesHours.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
        _booked.Add(slot);
        return true;
    }
    private DateTimeOffset Align(DateTimeOffset from)
    {
        var minutes = from.Minute - (from.Minute % bussinesHours.SlotMinutes);
        return new DateTimeOffset(from.Year, from.Month, from.Day, from.Hour, minutes, 0, from.Offset);
    }
}
