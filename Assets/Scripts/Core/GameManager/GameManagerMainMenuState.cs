using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class GameManagerMainMenuState : GameManagerBaseState
    {
        public override void EnterState(GameStateManager context)
        {
            context.SetInMainMenuBoolVariable(true);
            context.HandleOnMainMenuGameEvent(true);
        }

        public override void HandleTransitionState(GameStateManager context)
        {
            //disable main menu
            context.SetInMainMenuBoolVariable(false);
            context.HandleOnMainMenuGameEvent(false);
            //switch to next state
            context.SwitchState(context.GameManagerInGameState);
        }
    }
}
//EOF.