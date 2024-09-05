using UnityEditor;

using UnityEngine;

namespace Framework.Editor.PrefabEditor
{
    [CustomEditor(typeof(Object))]
    public class PrefabEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Custom Editor for Prefab");

            if (GUILayout.Button("Update Scope Fields"))
            {
                PrefabUpdater.UpdateScopePrefab(target);
            }

            DrawDefaultInspector();
        }
    }
}