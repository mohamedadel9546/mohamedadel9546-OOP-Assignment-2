using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.WardBoard;

public class PagerLog
{
    private readonly List<string> _pagerLog = new();
    public void NotifyIfCritical(int bed, int acuityScore)
    {
        if (acuityScore >= 8)
        {
            _pagerLog.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");
        }
    }
    public IReadOnlyList<string> DrainPagerLog()
    {
        var copy = _pagerLog.ToList();
        _pagerLog.Clear();
        return copy;
    }
}
