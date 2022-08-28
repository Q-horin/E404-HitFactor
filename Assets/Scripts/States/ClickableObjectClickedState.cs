using UnityEngine;

namespace E404.Core
{
    public class ClickableObjectClickedState : ClickableObjectBaseState
    {
        public override void Clicked(ClickableObjectStateManager context)
        {
            //Nothing happens because object was already clicked.
        }

        public override void EnterState(ClickableObjectStateManager context)
        {
            //SwitchState to Discarded
            //Update score properly:
            context.SetWasPressed(true);
            context.GetMyClickableObjectConfig().HandleObjectClicked();
            //Handle state transition:
            context.SwitchState(context.DiscardedState);
        }

        public override void UpdateState(ClickableObjectStateManager context)
        {
            //Nothing happens because after dealing with click the object goes to Discarded State.
        }
    }
}
//EOF.