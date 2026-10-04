using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.CheckOutBasket;

public class GrandTotal
{
    private readonly AddLines addLines=null!;
    private readonly CalculateDiscount discount=null!;

    public GrandTotal(AddLines addLines, CalculateDiscount discount)
    {
        this.addLines = addLines;
        this.discount = discount;
    }

    public decimal Grand_Total()
    {
        var total = addLines.SubTotal() - discount.DiscountAmount();
        if (addLines._giftWrap) total += 4.99m; // packaging fee policy ≠ cart math
        return Math.Max(0m, total);
    }
}
