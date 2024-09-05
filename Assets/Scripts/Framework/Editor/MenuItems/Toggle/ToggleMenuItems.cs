using Framework.Editor.AssembliesRefresh;
using Framework.Editor.ScriptTemplateModifier;

using UnityEditor;

namespace Framework.Editor.MenuItems.Toggle
{
    public class ToggleMenuItems
    {
        private static readonly IToggleOptions item1 = new AssembliesRefreshOptions();
        private static readonly IToggleOptions item2 = new ScriptTemplateProcessorOptions();

        [MenuItem(MenuItemPath.AUTO_REFRESH_TOGGLE_PATH)]
        private static void ToggleItem1()
        {
            item1.Toggle();
        }

        [MenuItem(MenuItemPath.AUTO_REFRESH_TOGGLE_PATH, true)]
        private static bool ToggleItemValidate1()
        {
            return item1.ToggleValidate();
        }

        [MenuItem(MenuItemPath.SCRIPT_TEMPLATE_PROCESSOR_TOGGLE_PATH)]
        private static void ToggleItem2()
        {
            item2.Toggle();
        }

        [MenuItem(MenuItemPath.SCRIPT_TEMPLATE_PROCESSOR_TOGGLE_PATH, true)]
        private static bool ToggleItemValidate2()
        {
            return item2.ToggleValidate();
        }
    }
}
