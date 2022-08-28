using System;
using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    [Serializable] public class UnityEventGameDifficulty : UnityEvent<GameDifficulty> { }
  
    public class GameListenerGameDifficulty : GameEventListener<GameDifficulty>
    {
        [SerializeField] private GameEventGameDifficulty gameEventGameDifficulty;
        [SerializeField] private UnityEventGameDifficulty unityEventGameDifficulty;

        public override UnityEvent<GameDifficulty> UnityEvent => unityEventGameDifficulty;
        public override GameEvent<GameDifficulty> GameEvent => gameEventGameDifficulty;
    }
}
//EOF.