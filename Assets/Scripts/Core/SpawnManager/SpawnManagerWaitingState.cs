using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class SpawnManagerWaitingState : SpawnManagerBaseState
    {
        int minTimeBetweenSpawns;
        int maxTimeBetweenSpawns;
        float spawnTimer;
        int spawnWaitTime;

        public override void EnterState(SpawnManager context)
        {
            spawnTimer = 0f;
            minTimeBetweenSpawns = context.GetMinTimeBetweenSpawns();
            maxTimeBetweenSpawns = context.GetMaxTimeBetweenSpawns();
            spawnWaitTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns + 1);
        }

        public override void UpdateState(SpawnManager context)
        {
            if (spawnTimer % 60 > spawnWaitTime)
            {
                //Handle state transition:
                context.SwitchState(context.spawnManagerSpawningState);
            }
            spawnTimer += Time.deltaTime;
        }
    }
}
//EOF.