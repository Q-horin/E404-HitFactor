using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    public class GameEvent<T> : ScriptableObject
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<IEventListener<T>> eventListeners = 
            new List<IEventListener<T>>();

        public void Raise(T go)
        {
            for(int i = eventListeners.Count -1; i >= 0; i--)
                eventListeners[i].OnEventRaised(go);
        }

        public void RegisterListener(IEventListener<T> listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(IEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}
//EOF.