using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace E404.Core
{
    [CreateAssetMenu(fileName ="SO Custom Data", menuName = "SO Custom Data/New Clickable Object Config List Variable")]
    public class ClickableObjectConfigListVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public List<ClickableObjectConfig> Value;

        public void SetValue(List<ClickableObjectConfig> value)
        {
            Value = value;
        }

        public void SetValue(ClickableObjectConfigListVariable value)
        {
            Value = value.Value;
        }

        public void AddClickableObjectConfig(ClickableObjectConfig clickableObjectConfig)
        {
            Value.Add(clickableObjectConfig);
        }

        public void RemoveClickableObjectConfig(ClickableObjectConfig clickableObjectConfig)
        {
            Value.Remove(clickableObjectConfig);
        }
    }
}
//EOF.