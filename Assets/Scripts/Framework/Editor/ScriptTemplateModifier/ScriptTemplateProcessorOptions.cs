using Framework.Editor.EditorPaths;
using Framework.Editor.MenuItems;
using Framework.Editor.MenuItems.Toggle;

namespace Framework.Editor.ScriptTemplateModifier
{
    public class ScriptTemplateProcessorOptions : ToggleBaseOptions
    {
        public ScriptTemplateProcessorOptions()
             : base(MenuItemPath.SCRIPT_TEMPLATE_PROCESSOR_TOGGLE_PATH, EditorPrefsKeywords.SCRIPT_TEMPLATE_PROCESSOR_KEY)
        { }

        public override void Enable()
        {
            base.Enable();
        }

        public override void Disable()
        {
            base.Disable();
        }
    }
}