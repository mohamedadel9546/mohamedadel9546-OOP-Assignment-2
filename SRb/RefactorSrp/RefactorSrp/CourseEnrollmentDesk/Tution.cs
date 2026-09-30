using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.CourseEnrollmentDesk;

public class Tution
{
    private readonly Rgister rgister = null!;

    public Tution(Rgister rgister)
    {
        this.rgister = rgister;
    }

    public string TuitionInvoiceLine(string studentEmail)
    {
        // Finance formatting / tax later — separate from enrollment capacity.
        if (!rgister.Seated.Contains(studentEmail)) return $"{rgister.CourseCode},WAITLIST,0.00";
        var vat = Math.Round(rgister.Tuition * 0.14m, 2);
        return $"{rgister.CourseCode},TUITION,{rgister.Tuition:0.00},VAT,{vat:0.00},TOTAL,{(rgister.Tuition + vat):0.00}";
    }
}
