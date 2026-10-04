using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.KitchenTicket
{
    public class LaneHint
    {
        private readonly IngredientAllergenDetector ingredient = null!;
        private readonly ReadyMinutes readyMinutes = null!;

        public LaneHint(IngredientAllergenDetector ingredient, ReadyMinutes readyMinutes)
        {
            this.ingredient = ingredient;
            this.readyMinutes = readyMinutes;
        }

        public string ExpoLaneHint()
        {
            return ingredient.DetectAllergens().Count > 0 ? "LANE-ALLERGY" : readyMinutes.EstimatedReadyMinutes(2) > 20 ? "LANE-SLOW" : "LANE-FAST";
        }
    }
}
