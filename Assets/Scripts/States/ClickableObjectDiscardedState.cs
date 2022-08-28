using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class ClickableObjectDiscardedState : ClickableObjectBaseState
    {
        public override void Clicked(ClickableObjectStateManager context)
        {
            //Nothing happens because we destroy the object on EnterState function
        }

        public override void EnterState(ClickableObjectStateManager context)
        {
            Object.Destroy(context.gameObject);
        }

        public override void UpdateState(ClickableObjectStateManager context)
        {
             //Nothing happens because we destroy the object on EnterState function
        }
    }
}
//EOF.