using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    [CreateAssetMenu(fileName ="Game Difficulty", menuName = "Game Difficulty/New Game Difficulty")]
    public class GameDifficulty : ScriptableObject
    {
        [SerializeField] int minTimeBetweenSpawns;
        [SerializeField] int maxTimeBetweenSpawns;
        [SerializeField] int minClickableObjectSpawned;
        [SerializeField] int maxClickableObjectSpawned;
        //Using NonReoderable as there is a pretty anoying bug on version below 5f1
        [SerializeField][NonReorderable] SpawnChancePercentage[] clickableObjectSpawnChancePercentageArray;

        public int GetMinTimeBetweenSpawns() => minTimeBetweenSpawns;
        public int GetMaxTimeBetweenSpawns() => maxTimeBetweenSpawns;
        public int GetMinClickableObjectSpawned() => minClickableObjectSpawned;
        public int GetMaxClickableObjectSpawned() => maxClickableObjectSpawned;
        public SpawnChancePercentage[] GetSpawnChancePercentageArray() => clickableObjectSpawnChancePercentageArray;
    }
}
//EOF.