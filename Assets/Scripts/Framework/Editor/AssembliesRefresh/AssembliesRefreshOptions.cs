using Framework.Editor.EditorPaths;
using Framework.Editor.MenuItems;
using Framework.Editor.MenuItems.Toggle;

using UnityEditor;

namespace Framework.Editor.AssembliesRefresh
{
    public class AssembliesRefreshOptions : ToggleBaseOptions
    {
        public AssembliesRefreshOptions()
        : base(MenuItemPath.AUTO_REFRESH_TOGGLE_PATH, EditorPrefsKeywords.AUTO_REFRESH_KEY)
        { }

        public override void Enable()
        {
            base.Enable();

            EditorApplication.UnlockReloadAssemblies();
            Refresh();
        }

        public override void Disable()
        {
            base.Disable();

            EditorApplication.LockReloadAssemblies();
            AssetDatabase.SaveAssets();
        }

        private void Refresh()
        {
            EditorUtility.RequestScriptReload();
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }
    }
}