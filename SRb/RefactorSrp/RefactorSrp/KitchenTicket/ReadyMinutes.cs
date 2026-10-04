using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.KitchenTicket
{
    public class ReadyMinutes
    {
        private readonly ADDITEM aDDITEM = null!;
        private readonly IngredientAllergenDetector ingredient = null!;

        public ReadyMinutes(ADDITEM aDDITEM, IngredientAllergenDetector ingredient)
        {
            this.aDDITEM = aDDITEM;
            this.ingredient = ingredient;
        }

        public int EstimatedReadyMinutes(int openStations)
        {
            // Kitchen ops model ≠ printing.
            if (openStations <= 0) openStations = 1;
            var sequential = aDDITEM.Items.Sum(i => i.PrepMinutes);
            var parallel = (int)Math.Ceiling(sequential / (double)openStations);
            if (ingredient.DetectAllergens().Count > 0) parallel += 3; // allergy protocol delay mixed in
            var longest = aDDITEM.Items.Count == 0 ? 0 : aDDITEM.Items.Max(i => i.PrepMinutes);
            return Math.Max(parallel, longest);
        }
    }
}
