using UnityEngine;

namespace E404.Core
{
    public class ClickableObjectStateManager : MonoBehaviour
    {
        [SerializeField] ClickableObjectConfig myClickableObjectConfig;
        ClickableObjectBaseState currentState;
        private bool wasPressed = false;

        public ClickableObjectClickedState ClickedState = new ClickableObjectClickedState();
        public ClickableObjectSpawnedState SpawnedState = new ClickableObjectSpawnedState();
        public ClickableObjectDissapearedState DissapearedState = new ClickableObjectDissapearedState();
        public ClickableObjectDiscardedState DiscardedState = new ClickableObjectDiscardedState();

        void Start()
        {
            currentState = SpawnedState;
            currentState.EnterState(this);
        }

        void Update()
        {
            currentState.UpdateState(this);
        }

        public void SwitchState(ClickableObjectBaseState state)
        {
            currentState = state;
            state.EnterState(this);
        }

        void OnMouseDown() 
        {
            currentState.Clicked(this);
        }   

        public void HandleGameEnd(bool hasGameEnded)
        {
            if (hasGameEnded)
            {
                currentState = DiscardedState;
                currentState.EnterState(this);
            }
        }

        public ClickableObjectConfig GetMyClickableObjectConfig() => myClickableObjectConfig;
        public bool GetWasPressed() => wasPressed;
        public void SetWasPressed(bool value) => wasPressed = value;
    }
}//EOF.