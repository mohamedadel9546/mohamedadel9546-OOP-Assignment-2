using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.WarehousePickList
{
    public class ADDNeed
    {
        private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();
        public IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> Lines => _lines;
        public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
        {
            _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
        }
    }
}
