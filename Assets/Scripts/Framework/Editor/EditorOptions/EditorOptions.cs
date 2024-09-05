using Framework.Editor.EditorPaths;

using UnityEditor;

namespace Framework.Editor.EditorOptions
{
    [InitializeOnLoad]
    public class EditorOptions
    {
        static EditorOptions()
        {
        }

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            if (EditorPrefs.GetInt(EditorPrefsKeywords.AUTO_REFRESH_KEY) == 0)
                EditorApplication.LockReloadAssemblies();
            else
                EditorApplication.UnlockReloadAssemblies();
        }
    }
}