using UnityEngine;
using E404.Core;
using TMPro;

namespace E404.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Canvas set up section")]
        [SerializeField] Canvas mainMenuCanvas;
        [SerializeField] Canvas inGameCanvas;
        [SerializeField] Canvas endScreenCanvas;
        [SerializeField] TextMeshProUGUI endMessageText;
        [SerializeField] StringVariable EndMessage;
        [SerializeField] TextMeshProUGUI scoreEndMessageText;
        [SerializeField] IntVariable Points;

        [Header("Game Events & Variable set up section")]
        [SerializeField] BoolVariable BackToMainMenuButtonPressed;
        [SerializeField] BoolVariable RestartButtonPressed;
        [SerializeField] BoolVariable StartButtonPressed;
        [SerializeField] GameEventBool OnBackToMainMenuButtonPressed;
        [SerializeField] GameEventBool OnRestartButtonPressed;
        [SerializeField] GameEventBool OnStartButtonPressed;
        [SerializeField] GameEventGameDifficulty OnGameDifficultySelected;

        //Handle Canvas Display:

        public void HandleMainMenuDisplay(bool isActive)
        {
            mainMenuCanvas.gameObject.SetActive(isActive);
            inGameCanvas.gameObject.SetActive(!isActive);
            endScreenCanvas.gameObject.SetActive(!isActive);
        }

        public void HandleInGameDisplay(bool isActive)
        {
            inGameCanvas.gameObject.SetActive(isActive);
            mainMenuCanvas.gameObject.SetActive(!isActive);
            endScreenCanvas.gameObject.SetActive(!isActive);
        }

        public void HandleEndScreenDisplay(bool isActive)
        {
            endScreenCanvas.gameObject.SetActive(isActive);
            mainMenuCanvas.gameObject.SetActive(!isActive);
            inGameCanvas.gameObject.SetActive(!isActive);

            endMessageText.text = EndMessage.Value;
            
            scoreEndMessageText.text = "Score: " + Points.Value;
        }

        //Handle Buttons Pressed:
        public void HandleStartButtonPressed()
        {
            StartButtonPressed.SetValue(true);
            OnStartButtonPressed.Raise(StartButtonPressed.Value);
            StartButtonPressed.SetValue(false);

        }

        public void HandleRestartButtonPressed()
        {
            RestartButtonPressed.SetValue(true);
            OnRestartButtonPressed.Raise(RestartButtonPressed.Value);
            RestartButtonPressed.SetValue(false);
        }

        public void HandleBackToMainMenuButtonPressed()
        {
            BackToMainMenuButtonPressed.SetValue(true);
            OnBackToMainMenuButtonPressed.Raise(BackToMainMenuButtonPressed.Value);
            BackToMainMenuButtonPressed.SetValue(false);
        }

        public void HandleGameDifficultySelection(GameDifficulty gameDifficulty)
        {
            OnGameDifficultySelected.Raise(gameDifficulty);
        }
    }
}
//EOF.