using System;
using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    [Serializable] public class UnityEventIntVariable : UnityEvent<IntVariable> { }
  
    public class GameListenerIntVariable : GameEventListener<IntVariable>
    {
        [SerializeField] private GameEventIntVariable gameEventIntVariable;
        [SerializeField] private UnityEventIntVariable unityEventIntVariable;

        public override UnityEvent<IntVariable> UnityEvent => unityEventIntVariable;
        public override GameEvent<IntVariable> GameEvent => gameEventIntVariable;
    }
}
//EOF.