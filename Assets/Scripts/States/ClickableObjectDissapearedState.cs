using UnityEngine;

namespace E404.Core
{
    public class ClickableObjectDissapearedState : ClickableObjectBaseState
    {
        public override void Clicked(ClickableObjectStateManager context)
        {
            //Nothing happens, you cannot click a dissapeared object;
        }

        public override void EnterState(ClickableObjectStateManager context)
        {
            //Set object to discarded state
            //Handle Score
            context.GetMyClickableObjectConfig().HandleObjectDissapeared();
            //Handle state transition:
            context.SwitchState(context.DiscardedState);
        }

        public override void UpdateState(ClickableObjectStateManager context)
        {
            //Nothing happens, object has been handled on EnterState function.
        }
    }
}
//EOF.