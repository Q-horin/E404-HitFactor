using System;
using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    [Serializable] public class UnityEventBool : UnityEvent<bool> { }
  
    public class GameListenerBool : GameEventListener<bool>
    {
        [SerializeField] private GameEventBool gameEventBool;
        [SerializeField] private UnityEventBool unityEventBool;

        public override UnityEvent<bool> UnityEvent => unityEventBool;
        public override GameEvent<bool> GameEvent => gameEventBool;
    }
}
//EOF.
