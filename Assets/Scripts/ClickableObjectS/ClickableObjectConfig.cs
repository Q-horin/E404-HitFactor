using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    [CreateAssetMenu(fileName ="Clickable Object", menuName = "Clickable Object/New Clickable Object", order = 0)]
    public class ClickableObjectConfig : ScriptableObject
    {
        [SerializeField] int clickedValue;
        [SerializeField] int dissapearValue;
        [SerializeField] int clickEfforts;
        [SerializeField] int longevity = 5;
        [SerializeField] ClickableObject clickableObjectPrefab;
        [SerializeField] GameEventInt OnObjectClicked;
        [SerializeField] GameEventInt OnObjectDissapeared;
        [SerializeField] bool doINeedAnAdditionalGameEventToHandleClick;
        [SerializeField] GameEventClickableObjectConfig OnSpecialClickableObjectClicked;
        [SerializeField] int numOfClickableObjectsToSpawn;
        [SerializeField] ClickableObjectConfig clickableObjectConfigToSpawn;
    
        public ClickableObject Spawn(Vector3 position)
        {
            ClickableObject clickableObject = Instantiate(clickableObjectPrefab, position, Quaternion.identity);
            return clickableObject;
        }

        public void HandleObjectClicked()
        {
            OnObjectClicked.Raise(clickedValue);
            if (doINeedAnAdditionalGameEventToHandleClick)
            {
                OnSpecialClickableObjectClicked.Raise(this);
            }
        }

        public void HandleObjectDissapeared()
        {
            OnObjectDissapeared.Raise(dissapearValue);
        }

        public int GetLongevity() => longevity;
        public int GetValue() => clickedValue;
        public int GetClickEfforts() => clickEfforts;
        public int GetDissapearValue() => dissapearValue;  
        public int GetNumOfClickableObjectsToSpawn() => numOfClickableObjectsToSpawn;
        public ClickableObjectConfig ClickableObjectConfigToSpawn() => clickableObjectConfigToSpawn;
        public ClickableObject GetClickableObjectPreFab() => clickableObjectPrefab;
    }

}
//EOF.