using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.WarehousePickList
{
    public class ALLocate
    {
        private readonly ADDNeed aDDNeed = null!;

        public ALLocate(ADDNeed aDDNeed)
        {
            this.aDDNeed = aDDNeed;
        }

        public IReadOnlyList<(string Sku, int Allocated)> Allocate()
        {
            // Allocation/backorder policy ≠ walking path ≠ human instructions.
            var result = new List<(string, int)>();
            foreach (var line in aDDNeed.Lines)
            {
                var alloc = Math.Min(line.QtyNeeded, line.QtyOnHand);
                result.Add((line.Sku, alloc));
            }
            return result;
        }
    }
}
