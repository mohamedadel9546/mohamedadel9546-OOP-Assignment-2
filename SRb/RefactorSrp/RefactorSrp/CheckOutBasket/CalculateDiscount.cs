using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.CheckOutBasket;

public class CalculateDiscount
{
    private string? _couponRaw;
    private readonly AddLines addLines = null!;

    public CalculateDiscount(AddLines addLines)
    {
        this.addLines = addLines;
    }

    public void ApplyCouponText(string? couponText) => _couponRaw = couponText;
    public decimal DiscountAmount()
    {
        // Parsing marketing strings is a different reason to change than pricing math.
        if (string.IsNullOrWhiteSpace(_couponRaw)) return 0m;
        var t = _couponRaw.Trim().ToUpperInvariant();
        if (t.StartsWith("SAVE") && int.TryParse(t[4..], out var pct) && pct is > 0 and <= 50)
            return Math.Round(addLines.SubTotal() * pct / 100m, 2);
        if (t.Contains("FREESHIP")) return 0m; // ship is elsewhere — still parsed here
        if (t == "WELCOME10") return Math.Min(10m, addLines.SubTotal());
        return 0m;
    }
}
