using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.SubscriptionBilling
{
    public class InvoiceNumber
    {
        private static int _invoiceSeq = 1000;
        private readonly AddSubscribe addSubscribe = null!;

        public InvoiceNumber(AddSubscribe addSubscribe)
        {
            this.addSubscribe = addSubscribe;
        }

        public string NextInvoiceNumber()
        {
            // Numbering scheme / fiscal prefixes — ops concern, not pricing.
            var n = ++_invoiceSeq;
            return $"INV-{addSubscribe.PeriodStart:yyyyMM}-{n:D5}";
        }
    }
}
