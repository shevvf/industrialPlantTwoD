using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;

using UnityEditor;

namespace Framework.Editor.PrefabEditor
{
    public class PrefabLifetimeScopeEditor
    {
        [CustomEditor(typeof(SwitchableMainScope))]
        public class SwitchableMainScopeEditor : PrefabEditor
        {

        }
    }
}