using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.SubscriptionBilling
{
    public class JournalLine
    {
        private readonly Proorate proorate = null!;
        private readonly AddSubscribe addSubscribe = null!;
        private readonly InvoiceNumber invoiceNumber = null!;

        public JournalLine(Proorate proorate, AddSubscribe addSubscribe, InvoiceNumber invoiceNumber)
        {
            this.proorate = proorate;
            this.addSubscribe = addSubscribe;
            this.invoiceNumber = invoiceNumber;
        }

        public string LedgerJournalLine(DateOnly activeFrom)
        {
            // Accounting export format is another axis of change.
            return $"{addSubscribe.CustomerId},{invoiceNumber.NextInvoiceNumber()},{proorate.Prorate(activeFrom):0.00},AR-SUB";
        }
    }
}
