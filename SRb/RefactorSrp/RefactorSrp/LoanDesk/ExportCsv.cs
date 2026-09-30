using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.LoanDesk
{
      
    public class ExportCsv
    {
        private readonly AddLoan addLoan = null!;
        private readonly CalculateRisk CalculateRisk = null!;

        public ExportCsv(AddLoan addLoan,CalculateRisk calculateRisk)
        {
            this.addLoan = addLoan;
            CalculateRisk = calculateRisk;
        }

        public string UnderwriterCsvRow(string applicationId)
        {
            // Analytics export schema is yet another reason to change.
            return $"{applicationId},{addLoan.CreditScore},{addLoan.EmploymentMonths},{(addLoan.HasCollateral ? 1 : 0)},{CalculateRisk.RiskScore():0.00},{(CalculateRisk.IsEligible() ? "Y" : "N")}";
        }
    }
}
