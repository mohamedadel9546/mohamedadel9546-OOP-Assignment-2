
using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.LoanDesk;

public class RequireDocument
{
    private readonly AddLoan addLoan = null!;
    private readonly CalculateRisk CalculateRisk = null!;

    public RequireDocument(AddLoan addLoan, CalculateRisk calculateRisk)
    {
        this.addLoan = addLoan;
        CalculateRisk = calculateRisk;
    }

    public IReadOnlyList<string> RequiredDocuments()
    {
        // Compliance checklist changes with regulation, independently of risk formula.
        var docs = new List<string> { "National ID", "Proof of income (3 months)" };
        if (addLoan.RequestedAmount > 40_000m) docs.Add("Bank statements (6 months)");
        if (addLoan.HasCollateral) docs.Add("Collateral ownership deed");
        if (addLoan.EmploymentMonths < 12) docs.Add("Employer letter");
        if (!CalculateRisk.IsEligible()) docs.Add("Manual underwriter referral form");
        return docs;
    }
}
