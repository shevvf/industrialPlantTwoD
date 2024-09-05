namespace IndustrialPlant.Infrastructure.Factories.UIFactory
{
    public interface IUIFactory : IEntryPoint
    {
        void CreateMainHUD();
        void CreateInitSwitchable();
        void CreateEnterPopUps();
    }
}