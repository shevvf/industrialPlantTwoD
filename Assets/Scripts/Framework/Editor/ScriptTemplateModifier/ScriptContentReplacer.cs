using Framework.Editor.ScriptTemplateModifier.Keywords;
using Framework.Extensions;

namespace Framework.Editor.ScriptTemplateModifier
{
    public static class ScriptContentReplacer
    {
        public static string ReplaceNamespace(string content, string directoryPath)
        {
            string newNamespace = ScriptAssetExtensions.GetNamespaceFromPath(directoryPath);
            return content.Replace(ScriptTemplateKeywords.NAMESPACE_KEY, newNamespace);
        }

        public static string ReplaceScriptName(string content, string className)
        {
            return content.Replace(ScriptTemplateKeywords.CLASSNAME_KEY, className);
        }

        public static string RemoveTrimDirective(string content)
        {
            return content.Replace(ScriptTemplateKeywords.NOTRIM_KEY, "");
        }
    }
}