using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.WarehousePickList
{
    public class WAlkingOredr
    {
        private readonly ADDNeed aDDNeed = null!;

        public WAlkingOredr(ADDNeed aDDNeed)
        {
            this.aDDNeed = aDDNeed;
        }

        public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
        {
            // Path heuristic will change with warehouse layout tech.
            return aDDNeed.Lines
                .OrderBy(l => l.Aisle)
                .ThenBy(l => l.Bin)
                .Select(l => (l.Aisle, l.Bin, l.Sku, Math.Min(l.QtyNeeded, l.QtyOnHand)))
                .Where(x => x.Item4 > 0)
                .ToList();
        }
    }
}
