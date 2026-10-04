using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.CheckOutBasket
{
    public class Payment
    {
        private readonly AddLines addLine = null!;
        private readonly GrandTotal grandTotal = null!;

        public Payment(AddLines addLine, GrandTotal grandTotal)
        {
            this.addLine = addLine;
            this.grandTotal = grandTotal;
        }

        public string AuthorizePaymentStub(string cardLast4)
        {
            // Pretends to talk to a gateway — auth scheme changes independently of cart rules.
            var payload = $"{grandTotal.Grand_Total():0.00}|{cardLast4}|{addLine.Lines.Count}";
            var hash = payload.GetHashCode();
            return $"AUTH-{Math.Abs(hash):X8}";
        }
    }
}
