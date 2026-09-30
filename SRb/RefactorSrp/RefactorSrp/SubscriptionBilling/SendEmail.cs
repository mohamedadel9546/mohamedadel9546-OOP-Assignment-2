using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.SubscriptionBilling
{
    public class SendEmail
    {
        private readonly InvoiceNumber invoiceNumber = null!;
        private readonly Proorate proorate = null!;
        private readonly AddSubscribe addSubscribe = null!;

        public SendEmail(InvoiceNumber invoiceNumber, Proorate proorate, AddSubscribe addSubscribe)
        {
            this.invoiceNumber = invoiceNumber;
            this.proorate = proorate;
            this.addSubscribe = addSubscribe;
        }

        public string DunningEmail(string customerName, DateOnly asOf)
        {
            // Collections tone & legal boilerplate ≠ proration formula.
            var amount = proorate.Prorate(addSubscribe.PeriodStart);
            var invoice = invoiceNumber.NextInvoiceNumber(); // side-effect while composing mail — nasty on purpose
            var severity = addSubscribe.FailedPayments switch
            {
                <= 1 => "friendly reminder",
                2 => "second notice",
                _ => "final notice before suspension"
            };
            return $"Subject: {severity} {invoice}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({addSubscribe.FailedPayments} failures).\n";
        }

    }
}
