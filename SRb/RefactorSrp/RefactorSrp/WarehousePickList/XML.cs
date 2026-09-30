using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.WarehousePickList
{
    public class XML
    {
        private readonly ALLocate aLLocate = null!;

        public XML(ALLocate aLLocate)
        {
            this.aLLocate = aLLocate;
        }

        public string WmsXmlBatch(string batchId)
        {
            // Integration contract with WMS — third reason to change.
            var parts = aLLocate.Allocate().Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
            return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
        }
    }
}
