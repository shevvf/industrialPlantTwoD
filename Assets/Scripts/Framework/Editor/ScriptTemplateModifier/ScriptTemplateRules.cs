using Framework.Editor.ScriptTemplateModifier.Keywords;

namespace Framework.Editor.ScriptTemplateModifier
{
    public static class ScriptTemplateRules
    {
        public static bool IsVContainerScope(this string className)
        {
            return className.Contains(ScriptTemplateRulesKeywords.VCONTAINER_SCOPE_KEY);
        }

        public static bool IsInterface(this string className)
        {
            return className[0] == ScriptTemplateRulesKeywords.INTERFACE_PREFIX_KEY;
        }
    }
}