using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.WardBoard;

public class AsignBed
{
    private readonly Dictionary<int, string> _bedPatient = new();
    public IReadOnlyDictionary<int, string> BedPatient => _bedPatient;

    private readonly Dictionary<int, int> _vitalsScore = new();
    public IReadOnlyDictionary<int, int> VitalsScore => _vitalsScore;

    private readonly CalculateScoreAcuity _scoreAcuity = new();
    private readonly PagerLog _pager = new();


    public void AssignBed(int bed, string patientId, int heartRate, int spo2)
    {
        if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
        if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
        _vitalsScore[bed] = _scoreAcuity.Scoreacuity(heartRate, spo2);

        _pager.NotifyIfCritical(bed,_vitalsScore[bed]);

  
           
    }

}
