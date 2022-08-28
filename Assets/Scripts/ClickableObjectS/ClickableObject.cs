using UnityEngine;
using UnityEngine.Events;

namespace E404.Core
{
    public class ClickableObject : MonoBehaviour
    {
        [SerializeField] ClickableObjectConfig objectToBeSpawned;
        [SerializeField] int numberOfTimesItShouldBeSpawned;

        public void HandleExtendedBehaviourOnClick()
        {
            SetClickableObjectConfigToBeSpawned();
            SetNumberOfClickableObjectToBeSpawned();
        }

        public ClickableObjectConfig SetClickableObjectConfigToBeSpawned()
        {
            throw new System.NotImplementedException();
        }

        public int SetNumberOfClickableObjectToBeSpawned()
        {
            throw new System.NotImplementedException();
        }
    }
}
//EOF.