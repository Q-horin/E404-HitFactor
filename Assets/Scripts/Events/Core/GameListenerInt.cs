using System;
using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    [Serializable] public class UnityEventInt : UnityEvent<int> { }
  
    public class GameListenerInt : GameEventListener<int>
    {
        [SerializeField] private GameEventInt gameEventInt;
        [SerializeField] private UnityEventInt unityEventInt;

        public override UnityEvent<int> UnityEvent => unityEventInt;
        public override GameEvent<int> GameEvent => gameEventInt;
    }
}
//EOF.