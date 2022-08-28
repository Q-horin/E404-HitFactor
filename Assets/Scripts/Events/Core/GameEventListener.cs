using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    public abstract class GameEventListener<T> : MonoBehaviour, IEventListener<T>
    {
        [Tooltip("Event to register with.")]
        public abstract GameEvent<T> GameEvent { get;}

        [Tooltip("Response to invoke when Event is raised.")]
        public abstract UnityEvent<T> UnityEvent { get; }


        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T value)
        {
            UnityEvent.Invoke(value);
        }
    }
}
//EOF.