using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.CheckOutBasket;

public class GiftMessage
{
    private readonly AddLines addLine = null!;
    private readonly GrandTotal grandTotal = null!;

    public GiftMessage(AddLines addLine, GrandTotal grandTotal)
    {
        this.addLine = addLine;
        this.grandTotal = grandTotal;
    }

    public string GiftMessageCard(string fromName)
    {
        // Customer-facing copy will change with marketing, not with totals.
        var items = string.Join(", ", addLine.Lines.Select(l => l.Sku));
        return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal.Grand_Total():C}\n";
    }

}
