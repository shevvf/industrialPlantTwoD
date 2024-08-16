using Framework.Editor.MenuItems;

using UnityEditor;

using UnityEngine;

namespace Framework.Editor.CopySelectFileGUID
{
    public class CopySelectFileGuid : EditorWindow
    {
        [MenuItem(MenuItemPath.GUID_COPY_PATH)]
        private static void GetSelectedAssetGuid()
        {
            if (Selection.assetGUIDs.Length > 0)
            {
                string selectedGUID = Selection.assetGUIDs[0];
                Debug.Log($"Selected asset {Selection.activeObject.name} GUID : {selectedGUID}");
                TextEditor textEditor = new()
                {
                    text = selectedGUID
                };
                textEditor.SelectAll();
                textEditor.Copy();
            }
            else
            {
                Debug.LogWarning("No asset selected");
            }
        }
    }
}
