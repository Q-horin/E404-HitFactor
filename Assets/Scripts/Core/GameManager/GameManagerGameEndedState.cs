using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class GameManagerGameEndedState : GameManagerBaseState
    {
        GameObject endScreenCanvas;

        public override void EnterState(GameStateManager context)
        {
            context.SetEndScreenMessage();
            context.SetInEndScreenBoolVariable(true);  
            context.HandleOnEndScreenGameEvent(true);  
        }

        public override void HandleTransitionState(GameStateManager context)
        {
            context.SetInEndScreenBoolVariable(false);
            context.HandleOnEndScreenGameEvent(false);
        }
    }
}
//EOF.