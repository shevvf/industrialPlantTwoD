using System.IO;

using Framework.Editor.EditorPaths;
using Framework.Extensions;

using UnityEditor;

namespace Framework.Editor.ScriptTemplateModifier
{
    public sealed class ScriptTemplateProcessor : AssetModificationProcessor
    {
        public static void OnWillCreateAsset(string metaPath)
        {
            if (EditorPrefs.GetInt(EditorPrefsKeywords.SCRIPT_TEMPLATE_PROCESSOR_KEY) == 0)
                return;

            string scriptPath = PathExtensions.GetPathFromMeta(metaPath);
            if (string.IsNullOrEmpty(scriptPath)) return;

            string extensionName = PathExtensions.GetExtensionName(scriptPath, FileExtensionsKey.SCRIPTS_EXTENSION_KEY);
            if (string.IsNullOrEmpty(extensionName)) return;

            string directoryPath = PathExtensions.GetDirectoryName(scriptPath);
            string className = PathExtensions.GetClassName(scriptPath);

            string templatePath = GetTemplatePath(className);
            if (string.IsNullOrEmpty(templatePath)) return;

            string content = ScriptGenerator.GenerateScriptContent(templatePath, directoryPath, className);

            scriptPath = scriptPath.StartsWith("Assets/") ? scriptPath["Assets/".Length..] : scriptPath;

            string fullPath = PathExtensions.CombineWithAppDataPath(scriptPath);

            File.WriteAllText(fullPath, content);

            EditorUtility.OpenWithDefaultApp(fullPath);
            AssetDatabase.Refresh();
        }

        private static string GetTemplatePath(string className)
        {
            string path = true switch
            {
                true when ScriptTemplateRules.IsVContainerScope(className) => AssetDatabase.GUIDToAssetPath(EditorTemplateGUID.VCONTAINER_SCOPE_TEMPLATE),
                true when ScriptTemplateRules.IsInterface(className) => AssetDatabase.GUIDToAssetPath(EditorTemplateGUID.BASE_INTERFACE_TEMPLATE),
                _ => AssetDatabase.GUIDToAssetPath(EditorTemplateGUID.BASE_CLASS_TEMPLATE),
            };
            return path;
        }
    }
}