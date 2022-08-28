using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class GameManagerInGameState : GameManagerBaseState
    {   
        GameObject inGameCanvas;
        
        public override void EnterState(GameStateManager context)
        {
            //Reset the game values
            //context.ResetVariables();
            //Set InGame to true;
            context.SetInGameBoolVariable(true);       
            context.HandleOnInGameGameEvent(true);
            //spawn manager
        }

        public override void HandleTransitionState(GameStateManager context)
        {
            //managed via gameevents
            context.SetInGameBoolVariable(false);
            context.HandleOnInGameGameEvent(false);
            context.SwitchState(context.GameManagerGameEndedState);
        }
    }
}
//EOF.