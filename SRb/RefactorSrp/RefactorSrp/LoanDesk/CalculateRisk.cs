using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.LoanDesk;

public class CalculateRisk
{
    private readonly AddLoan addLoan = null!;

    public CalculateRisk(AddLoan addLoan)
    {
        this.addLoan = addLoan;
    }

    public decimal RiskScore()
    {
        // Risk model will change with risk committee — not with letter templates.
        decimal score = 100m;
        score -= Math.Max(0, 700 - addLoan.CreditScore) * 0.15m;
        if (addLoan.EmploymentMonths < 6) score -= 20m;
        if (addLoan.RequestedAmount > 50_000m && !addLoan.HasCollateral) score -= 25m;
        if (addLoan.RequestedAmount > 150_000m) score -= 10m;
        return Math.Clamp(score, 0m, 100m);
    }

    public bool IsEligible() => RiskScore() >= 55m && addLoan.CreditScore >= 580;
}
