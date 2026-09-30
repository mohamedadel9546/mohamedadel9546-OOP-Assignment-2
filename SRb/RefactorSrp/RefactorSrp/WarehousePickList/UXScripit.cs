using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.WarehousePickList
{
    public class UXScripit
    {
        private readonly ADDNeed aDDNeed = null!;
        private readonly ALLocate Allocate = null!;
        private readonly WAlkingOredr wAlkingOredr = null!;

        public UXScripit(ADDNeed aDDNeed, ALLocate allocate, WAlkingOredr wAlkingOredr)
        {
            this.aDDNeed = aDDNeed;
            Allocate = allocate;
            this.wAlkingOredr = wAlkingOredr;
        }

        public string PickerScript()
        {
            // UX wording for handheld devices — separate owners.
            var steps = wAlkingOredr.WalkingOrder()
                .Select((s, i) => $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");
            var shortfalls = Allocate.Allocate().Where(a =>
            {
                var need = aDDNeed.Lines.First(l => l.Sku == a.Sku).QtyNeeded;
                return a.Allocated < need;
            });
            var warn = shortfalls.Any()
                ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
                : "SHORTAGES: none";
            return string.Join('\n', steps) + "\n" + warn;
        }
    }
}
