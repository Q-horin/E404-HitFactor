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
            Debug.Log("Spawn Wait Time: " + spawnWaitTime);

        }

        public override void UpdateState(SpawnManager context)
        {
            //If timer goes beyond my longevity the object should dissapear
            //This could be more sophisticated if performance allows it
            //Check if time is above minTimeBetweenSpawn and then
            //do percentage check using diff between min and max timeBetweenSpawn as total
            //to check if object should spawned
            //If math is set OK object will spawn in any time between min and max
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