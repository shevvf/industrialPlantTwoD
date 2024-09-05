using System;

using UnityEditor;

namespace Framework.Editor.MenuItems.Toggle
{
    public class ToggleBaseOptions : IToggleOptions
    {
        protected string MenuItemPathKey { get; set; }

        protected string ToggleStatusEditorPrefsKey { get; set; }

        #region Constructor

        public ToggleBaseOptions(string menuItemPath, string toggleStatusKey)
        {
            MenuItemPathKey = menuItemPath;
            ToggleStatusEditorPrefsKey = toggleStatusKey;
        }

        #endregion

        #region Public Methods

        public void Toggle()
        {
            int status = GetToggleStatus();
            (status == 0 ? new Action(Enable) : new Action(Disable))();
        }

        public bool ToggleValidate()
        {
            bool isChecked = GetToggleStatus() == 1;
            Menu.SetChecked(MenuItemPathKey, isChecked);
            return true;
        }

        public virtual void Enable()
        {
            SetToggleStatus(1);
        }

        public virtual void Disable()
        {
            SetToggleStatus(0);
        }

        #endregion

        #region Private Methods

        private void SetToggleStatus(int status)
        {
            EditorPrefs.SetInt(ToggleStatusEditorPrefsKey, status);
        }

        private int GetToggleStatus()
        {
            return EditorPrefs.GetInt(ToggleStatusEditorPrefsKey);
        }

        #endregion
    }
}
