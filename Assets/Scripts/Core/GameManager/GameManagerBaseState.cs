using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public abstract class GameManagerBaseState
    {
        public abstract void EnterState(GameStateManager context);

        public abstract void HandleTransitionState(GameStateManager context);
    }
}
//EOF.