using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] ClickableObjectConfigListVariable clickableObjectConfigList;
        [SerializeField] BoolVariable InGame;
        [SerializeField] BoolVariable SpecialClickableObjectClicked;
        [SerializeField] BoolVariable IsSpawnManagerStarted;
        [SerializeField] GameDifficulty currentGameDifficulty;
        [SerializeField] GameEventGameDifficulty OnGameDifficultySelected;
        [SerializeField] float raycastMaxDistance = -10f;

        // Difficulty and conf set up related fields:
        int minTimeBetweenSpawns;
        int maxTimeBetweenSpawns;
        int minClickableObjectSpawned;
        int maxClickableObjectSpawned;
        int numberOfObjects;
        int clickableObjectIndex;
        Dictionary<ClickableObjectConfig, float> clickableObjectSpawnPercentageDict = new Dictionary<ClickableObjectConfig, float>();
        ClickableObjectConfig specialClickableObjectConfig;

        // State related fields:
        SpawnManagerBaseState currentState;
        public SpawnManagerTurnedOffState spawnManagerTurnedOffState = new SpawnManagerTurnedOffState();
        public SpawnManagerSpawningState spawnManagerSpawningState = new SpawnManagerSpawningState();
        public SpawnManagerWaitingState spawnManagerWaitingState = new SpawnManagerWaitingState();

        private void Start() 
        {
            currentState = spawnManagerTurnedOffState;
            currentState.EnterState(this);
            SetDifficultyVariables();          
        }

        private void Update() 
        {
            currentState.UpdateState(this);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                HandleClickableObjectSpawn();
            }
        }

        public void SwitchState(SpawnManagerBaseState state)
        {
            currentState = state;
            state.EnterState(this);
        }

        public void HandleInGameStartUp()
        {
            //if (!InGame.Value)
            //{
                SetIsSpawnManagerStarted(true);
                currentState = spawnManagerSpawningState;
                currentState.EnterState(this);
            //}
        }

        public void HandleEndGameConditionMet()
        {
            currentState = spawnManagerTurnedOffState;
            currentState.EnterState(this);
        }

        public void HandleClickableObjectSpawn()
        {
            numberOfObjects = UnityEngine.Random.Range(minClickableObjectSpawned, maxClickableObjectSpawned);
            //clickableObjectIndex = GetRandomClickableObjectByIndex();
            clickableObjectIndex = GetRandomClickableObjectIndexByPercentage();
            if (SpecialClickableObjectClicked.Value) { SetSpawnLogicWithSpecialClickableObject(); }
            SpawnClickableObject(numberOfObjects, clickableObjectIndex);
        }

        private void SpawnClickableObject(int numberOfObjects, int clickableObjectIndex)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                int count = 0;           
                Vector3 position = GetRandomPosition();
                //TO DO: Think a better approach than this one
                // This should check for a free spawn slot on a grid
                // or something alike.
                while (!CanObjectSpawn(position) && count < 20)
                {
                    position = GetRandomPosition();
                    count++;
                }    
                if (CanObjectSpawn(position))
                {
                    clickableObjectConfigList.Value[clickableObjectIndex].Spawn(position);
                }
            }
        }
        
        bool CanObjectSpawn(Vector3 pos)
        {
            RaycastHit hit; 
            bool hittedCollider = true;
            Vector3 origin = new Vector3(pos.x, pos.y, 0);
            if (Physics.Raycast(origin, Vector3.forward, out hit, raycastMaxDistance))
            {
                hittedCollider = false;
            }
            return hittedCollider;
        }

        private int GetRandomClickableObjectByIndex()
        {
            return UnityEngine.Random.Range(0, clickableObjectConfigList.Value.Count);
        }

        private int GetRandomClickableObjectIndexByPercentage()
        {
            int index = 0;
            float random = UnityEngine.Random.Range(0f, 1f);
            float addingNum = 0;
            float total = 0;
            ClickableObjectConfig clickableObjectConfigToBeSpawned = null;

            foreach(KeyValuePair<ClickableObjectConfig, float> kvp in clickableObjectSpawnPercentageDict)
            {
                total += kvp.Value;
            }
            
            foreach(KeyValuePair<ClickableObjectConfig, float> kvp in clickableObjectSpawnPercentageDict)
            {
                if (kvp.Value / total + addingNum >= random)
                {
                    clickableObjectConfigToBeSpawned = kvp.Key;
                    break;
                }
                addingNum += kvp.Value / total;
            }

            if (clickableObjectConfigToBeSpawned != null)
            {
                index = clickableObjectConfigList.Value.FindIndex(x =>
                                                        x.ToString() == clickableObjectConfigToBeSpawned.ToString());
            }
            return index;
        }

        private static Vector3 GetRandomPosition()
        {
            return new Vector3(UnityEngine.Random.Range(-2, 3), UnityEngine.Random.Range(-3, 5), 1);
        }

        public void SetSpawnLogicWithSpecialClickableObject()
        {
            numberOfObjects = specialClickableObjectConfig.GetNumOfClickableObjectsToSpawn();
            clickableObjectIndex = clickableObjectConfigList.Value.FindIndex(x => 
                                                x.ToString() == specialClickableObjectConfig.ClickableObjectConfigToSpawn().ToString());
            SpecialClickableObjectClicked.SetValue(false);
        }

        public void HandleSpecialClickableObjectClicked(ClickableObjectConfig clickableObjectConfig)
        {
            SpecialClickableObjectClicked.SetValue(true);
            specialClickableObjectConfig = clickableObjectConfig;
        }

        public void HandleGameDifficultySelection(GameDifficulty gameDifficulty)
        {
            currentGameDifficulty = gameDifficulty;
            SetDifficultyVariables();
        }

        public void SetDifficultyVariables()
        {
            minTimeBetweenSpawns = currentGameDifficulty.GetMinTimeBetweenSpawns();
            maxTimeBetweenSpawns = currentGameDifficulty.GetMaxTimeBetweenSpawns();
            minClickableObjectSpawned = currentGameDifficulty.GetMinClickableObjectSpawned();
            //Adding one since Unity Random is max exclusive;
            maxClickableObjectSpawned = currentGameDifficulty.GetMaxClickableObjectSpawned() + 1;
            
            SpawnChancePercentage[] COPercentagesArray = currentGameDifficulty.GetSpawnChancePercentageArray();
            //Populate dictionary:
            //Probably don't need a dic, could just use the SpawnChancePercentageArray
            for (int i = 0; i < COPercentagesArray.Length; i++)
            {
                if (!clickableObjectSpawnPercentageDict.ContainsKey(COPercentagesArray[i].clickableObjectConfig))
                {
                    clickableObjectSpawnPercentageDict.Add(COPercentagesArray[i].clickableObjectConfig, COPercentagesArray[i].percentage);
                    continue;
                }  
                clickableObjectSpawnPercentageDict[COPercentagesArray[i].clickableObjectConfig] = COPercentagesArray[i].percentage;
            }
        }

        public void SetIsSpawnManagerStarted(bool value) => IsSpawnManagerStarted.SetValue(value);
        public BoolVariable GetIsSpawnManagerStarted() => IsSpawnManagerStarted;
        public int GetMinTimeBetweenSpawns() => minTimeBetweenSpawns;
        public int GetMaxTimeBetweenSpawns() => maxTimeBetweenSpawns;
    }
}
//EOF.