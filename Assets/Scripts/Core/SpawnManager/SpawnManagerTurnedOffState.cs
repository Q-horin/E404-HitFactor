using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class SpawnManagerTurnedOffState : SpawnManagerBaseState
    {
        public override void EnterState(SpawnManager context)
        {
            context.SetIsSpawnManagerStarted(false);
        }

        public override void UpdateState(SpawnManager context)
        {
        }
    }
}
//EOF.