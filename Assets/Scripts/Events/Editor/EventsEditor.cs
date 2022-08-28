using UnityEditor;
using UnityEngine;

namespace E404.Core
{
    /*
    [CustomEditor(typeof(GameEvent<>), editorForChildClasses: true)]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent<T> e = target as GameEvent<T>;
            if (GUILayout.Button("Raise"))
                e.Raise(T);
        }
    }
    */
}
//EOF.