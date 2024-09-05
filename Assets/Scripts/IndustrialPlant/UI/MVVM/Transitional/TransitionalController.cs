using IndustrialPlant.Data.StaticData.Configs;
using IndustrialPlant.Infrastructure.Factories.ViewFactory;
using IndustrialPlant.LifetimeScopes.MVVM.UI.Main;
using IndustrialPlant.UI.MVVM.Base.Controller;

namespace IndustrialPlant.UI.MVVM.Transitional
{
    public class TransitionalController : ViewController
    {
        public TransitionalController(TransitionalPanelsConfig panelsConfig, MainCanvasScope.UIFolder uIContainersFolder, IViewFactory viewFactory)
            : base(panelsConfig, uIContainersFolder.TransitionalPanelsHolder, viewFactory)
        {
        }
    }
}