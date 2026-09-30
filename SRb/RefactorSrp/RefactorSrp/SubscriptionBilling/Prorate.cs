using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.SubscriptionBilling
{
    public class Proorate
    {
        private readonly AddSubscribe addSubscribe = null!;

        public Proorate(AddSubscribe addSubscribe)
        {
            this.addSubscribe = addSubscribe;
        }

        public decimal Prorate(DateOnly activeFrom)
        {
            // Finance calendar rules change independently of email copy.
            if (activeFrom <= addSubscribe.PeriodStart) return addSubscribe.MonthlyPrice;
            if (activeFrom >= addSubscribe.PeriodEnd) return 0m;
            var totalDays = addSubscribe.PeriodEnd.DayNumber - addSubscribe.PeriodStart.DayNumber;
            if (totalDays <= 0) return addSubscribe.MonthlyPrice;
            var used = addSubscribe.PeriodEnd.DayNumber - activeFrom.DayNumber;
            return Math.Round(addSubscribe.MonthlyPrice * used / totalDays, 2);
        }
    }
}
