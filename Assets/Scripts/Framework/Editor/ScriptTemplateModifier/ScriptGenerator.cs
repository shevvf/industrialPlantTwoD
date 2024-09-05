using System.IO;
using static Framework.Editor.ScriptTemplateModifier.ScriptContentReplacer;

namespace Framework.Editor.ScriptTemplateModifier
{
    public sealed class ScriptGenerator
    {
        public static string GenerateScriptContent(string templatePath, string directoryPath, string className)
        {
            string content = File.ReadAllText(templatePath);
            content = ReplaceNamespace(content, directoryPath);
            content = ReplaceScriptName(content, className);
            content = RemoveTrimDirective(content);
            return content;
        }
    }
}