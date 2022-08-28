
using UnityEngine;

namespace E404.Core
{
    public class ClickableObjectSpawnedState : ClickableObjectBaseState
    {
        float timer = 0f;
        int longevity;
        //TO DO
        //Hardconding this, but this should be a IntVariable affected by dificulty selection
        int difficultyModifier = 1;
        int clickEfforts;
        int currentClicks;

        public override void Clicked(ClickableObjectStateManager context)
        {
            //Update current clicks
            currentClicks++;
            //Check if current clicks are equal or bigger than clickEffort
            if (!context.GetWasPressed() && currentClicks >= clickEfforts)
            {
            //Handle state transition:
            context.SwitchState(context.ClickedState);
            }
        }

        public override void EnterState(ClickableObjectStateManager context)
        {
            timer = 0f;
            currentClicks = 0;
            clickEfforts = context.GetMyClickableObjectConfig().GetClickEfforts();
            longevity = context.GetMyClickableObjectConfig().GetLongevity() * difficultyModifier;
        }

        public override void UpdateState(ClickableObjectStateManager context)
        {
            //If timer goes beyond my longevity the object should dissapear
            if (timer % 60 > longevity)
            {
                //Handle state transition:
                context.SwitchState(context.DissapearedState);
            }
            timer += Time.deltaTime;
        }
    }
}
//EOF.