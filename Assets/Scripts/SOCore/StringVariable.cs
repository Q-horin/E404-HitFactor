using UnityEngine;

namespace E404.Core
{
    [CreateAssetMenu(fileName ="SO Custom Data", menuName = "SO Custom Data/New String Variable")]
    public class StringVariable : ScriptableObject
    {
        [SerializeField]
        private string value = "";

        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
//EOF.