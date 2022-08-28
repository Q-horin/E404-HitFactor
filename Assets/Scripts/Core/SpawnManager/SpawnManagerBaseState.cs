using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public abstract class SpawnManagerBaseState
    {
        public abstract void EnterState(SpawnManager context);

        public abstract void UpdateState(SpawnManager context);
    }
}
//EOF.