using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.LoanDesk
{
    public class Decision_Letter
    {
        private readonly AddLoan addLoan = null!;
        private readonly CalculateRisk CalculateRisk = null!;
        private readonly RequireDocument RequireDocument = null!;

        public Decision_Letter(AddLoan addLoan, CalculateRisk calculateRisk, RequireDocument requireDocument)
        {
            this.addLoan = addLoan;
            CalculateRisk = calculateRisk;
            RequireDocument = requireDocument;
        }

        public string DecisionLetter(string applicantName)
        {
            // Legal/comms wording ≠ underwriting math.
            if (CalculateRisk.IsEligible())
            {
                return $"Dear {applicantName},\nYour request for {addLoan.RequestedAmount:C} is pre-approved (risk {CalculateRisk.RiskScore():0}).\n" +
                       $"Please upload: {string.Join("; ", RequireDocument.RequiredDocuments())}.\n";
            }

            return $"Dear {applicantName},\nWe are unable to approve {addLoan.RequestedAmount:C} at this time.\n" +
                   $"Reference risk={CalculateRisk.RiskScore():0}. You may reapply after improving documentation.\n";
        }
    }
}
