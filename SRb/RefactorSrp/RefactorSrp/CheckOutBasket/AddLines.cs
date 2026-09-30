using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.CheckOutBasket;

public class AddLines
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
    public IReadOnlyList<(string Sku, decimal Price, int Qty)> Lines => _lines;
    public bool _giftWrap { get; private set; }
    public void EnableGiftWrap() => _giftWrap = true;

    public decimal SubTotal() => _lines.Sum(l => l.Price * l.Qty);
    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _lines.Add((sku, price, qty));
    }
}
