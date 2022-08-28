using UnityEngine;

namespace E404.Core
{
    public abstract class ClickableObjectBaseState 
    {
        public abstract void EnterState(ClickableObjectStateManager context);

        public abstract void UpdateState(ClickableObjectStateManager context);

        public abstract void Clicked(ClickableObjectStateManager context);
    }
}
//EOF.