using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class SpawnManagerSpawningState : SpawnManagerBaseState
    {
        public override void EnterState(SpawnManager context)
        {
            context.HandleClickableObjectSpawn();
            context.SwitchState(context.spawnManagerWaitingState);
        }

        public override void UpdateState(SpawnManager context)
        {
        }
    }
}
//EOF.