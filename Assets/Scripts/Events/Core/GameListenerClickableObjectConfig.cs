using System;
using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    [Serializable] public class UnityEventClickableObjectConfig : UnityEvent<ClickableObjectConfig> { }
  
    public class GameListenerClickableObjectConfig : GameEventListener<ClickableObjectConfig>
    {
        [SerializeField] private GameEventClickableObjectConfig gameEventClickableObjectConfig;
        [SerializeField] private UnityEventClickableObjectConfig unityEventClickableObjectConfig;

        public override UnityEvent<ClickableObjectConfig> UnityEvent => unityEventClickableObjectConfig;
        public override GameEvent<ClickableObjectConfig> GameEvent => gameEventClickableObjectConfig;
    }
}
//EOF.
