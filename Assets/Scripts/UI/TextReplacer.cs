using TMPro;
using UnityEngine;
using E404.Core;

namespace E404.UI
{
    public class TextReplacer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI Text;
        [SerializeField] IntVariable Variable;
        [SerializeField] bool AlwaysUpdate;
        [SerializeField] string defaultText;
        [SerializeField] bool displayPredefinedStringVariable;
        [SerializeField] StringVariable PredifinedDisplayMessage;
        
        private void OnEnable()
        {
            if (displayPredefinedStringVariable)
            {
                Text.text = PredifinedDisplayMessage.Value;
            }
            else
            {
                Text.text = $"{defaultText}: {Variable.Value.ToString()}"; 
            }
        }

        private void Update()
        {
            if (AlwaysUpdate)
            {
                Text.text = $"{defaultText}: {Variable.Value.ToString()}"; 
            }
        }
    }
}
//EOF.