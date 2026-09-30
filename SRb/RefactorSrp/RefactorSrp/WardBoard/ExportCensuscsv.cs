using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.WardBoard;

public class ExportCensusCsv
{
    private readonly AsignBed asignBed = null!;

    public ExportCensusCsv(AsignBed asignBed)
    {
        this.asignBed = asignBed;
    }

    public string ExportCensuscsv()
    {
        // Persistence/export shape mixed into the same type as acuity + paging.
        var lines = new List<string> { "bed,patient,acuity" };
        foreach (var bed in asignBed.BedPatient.Keys.OrderBy(x => x))
            lines.Add($"{bed},{asignBed.BedPatient[bed]},{asignBed.VitalsScore[bed]}");
        return string.Join('\n', lines);
    }
}
