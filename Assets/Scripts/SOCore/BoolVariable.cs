using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    [CreateAssetMenu(fileName ="SO Custom Data", menuName = "SO Custom Data/New Bool Variable")]
    public class BoolVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public bool Value;

        public void SetValue(bool value)
        {
            Value = value;
        }

        public void SetValue(BoolVariable value)
        {
            Value = value.Value;
        }
    }
}
//EOF.