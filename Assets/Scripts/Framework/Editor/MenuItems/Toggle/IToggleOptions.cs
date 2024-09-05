namespace Framework.Editor.MenuItems.Toggle
{
    public interface IToggleOptions
    {
        #region Methods

        void Toggle();

        bool ToggleValidate();

        void Enable();

        void Disable();

        #endregion
    }
}