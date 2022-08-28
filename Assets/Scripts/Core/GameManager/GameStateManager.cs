using UnityEngine;

namespace E404.Core
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] BoolVariable HasPlayerWin;
        [SerializeField] BoolVariable InGame;
        [SerializeField] BoolVariable InMainMenu;
        [SerializeField] BoolVariable InEndScreen;
        [SerializeField] StringVariable EndScreenMessage;
        [SerializeField] StringVariable YouWinMessage;
        [SerializeField] StringVariable GameOverMessage;

        [SerializeField] GameEventBool OnTimeEnded;
        [SerializeField] GameEventBool OnMainMenu;
        [SerializeField] GameEventBool OnInGame;
        [SerializeField] GameEventBool OnEndScreen;

        [SerializeField] Canvas mainMenuCanvas;
        [SerializeField] Canvas inGameCanvas;
        [SerializeField] Canvas endScreenCanvas;

        GameManagerBaseState currentState;
        public GameManagerMainMenuState GameManagerMainMenuState = new GameManagerMainMenuState();
        public GameManagerInGameState GameManagerInGameState = new GameManagerInGameState();
        public GameManagerGameEndedState GameManagerGameEndedState = new GameManagerGameEndedState();

        void Start()
        {
            ResetVariables();
            currentState = GameManagerMainMenuState;
            currentState.EnterState(this);
        }

        public void SwitchState(GameManagerBaseState state)
        {
            currentState = state;
            state.EnterState(this);
        }

        public void ResetVariables()
        {
            InMainMenu.SetValue(false);
            InGame.SetValue(false);
            InEndScreen.SetValue(false);
            EndScreenMessage.Value = "";
        }

        public void HandleStateTransition()
        {
            currentState.HandleTransitionState(this);
        }

        public void HandleStartButtonPressedEvent(bool wasPressed)
        {
            if (wasPressed)
            {
                if (currentState == GameManagerMainMenuState)
                {
                    currentState.HandleTransitionState(this);
                }
                else 
                {
                    currentState = GameManagerInGameState;
                    currentState.EnterState(this);
                }
            }
        }

        public void HandleRestartButtonPressedEvent(bool wasPressed)
        {
            if (wasPressed)
            {
                if ( currentState == GameManagerGameEndedState)
                {
                    currentState.HandleTransitionState(this);
                    currentState = GameManagerInGameState;
                    currentState.EnterState(this);
                }
                else 
                {
                    currentState = GameManagerInGameState;
                    currentState.EnterState(this);
                }
            }
        }

        public void HandleBackToMainMenuButtonPressedEvent(bool wasPressed)
        {
            if (wasPressed)
            {
                if ( currentState == GameManagerGameEndedState)
                {
                    currentState.HandleTransitionState(this);
                }
                currentState = GameManagerMainMenuState;
                currentState.EnterState(this);
            }
        }

        public void HandleOnMainMenuGameEvent(bool value) => OnMainMenu.Raise(value);
        public void HandleOnInGameGameEvent(bool value) => OnInGame.Raise(value);
        public void HandleOnEndScreenGameEvent(bool value) => OnEndScreen.Raise(value);

        public void SetEndScreenMessage()
        {
            if (HasPlayerWin.Value)
            {
                EndScreenMessage.Value = YouWinMessage.Value;
            }
            else
            {
                EndScreenMessage.Value = GameOverMessage.Value;
            }
        }

        public void HandleTimeEnded(bool timeEnded)
        {
           if (currentState == GameManagerInGameState)
           {
                currentState.HandleTransitionState(this);
           }
        }

        public Canvas GetMainMenuCanvas() => mainMenuCanvas;
        public Canvas GetInGameCanvas() => inGameCanvas;
        public Canvas GetEndScreenCanvas() => endScreenCanvas;
        public void SetInGameBoolVariable(bool inGame) => InGame.Value = inGame;
        public void SetInMainMenuBoolVariable(bool inMainMenu) => InMainMenu.Value = inMainMenu;
        public void SetInEndScreenBoolVariable(bool inEndScreen) => InEndScreen.Value = inEndScreen;
    }
}
//EOF.