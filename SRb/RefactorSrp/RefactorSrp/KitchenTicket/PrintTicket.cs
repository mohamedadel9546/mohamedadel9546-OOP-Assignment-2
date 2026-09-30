using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.KitchenTicket
{
    public class PrintTicket
    {
        private readonly ADDITEM aDDITEM = null!;
        private readonly IngredientAllergenDetector ingredient = null!;
        private readonly ReadyMinutes ready = null!;

        public PrintTicket(ADDITEM aDDITEM, IngredientAllergenDetector ingredient, ReadyMinutes ready)
        {
            this.aDDITEM = aDDITEM;
            this.ingredient = ingredient;
            this.ready = ready;
        }

        public string RenderThermalTicket(int orderNumber)
        {
            // Hardware/formatting concerns — width, separators — change with printer vendor.
            var width = 32;
            var line = new string('=', width);
            var body = string.Join('\n', aDDITEM.Items.Select(i => $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));
            var allergens = ingredient.DetectAllergens();
            var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
            return $"{line}\nORDER #{orderNumber}\nETA {ready.EstimatedReadyMinutes(2)} MIN\n{body}\n{allergyLine}\n{line}\n";
        }
    }
}
