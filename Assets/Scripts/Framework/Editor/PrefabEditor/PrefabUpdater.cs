using IndustrialPlant.LifetimeScopes.MVVM.UI.Switchable;
using IndustrialPlant.UI.MVVM.Switchable.Main;

using TMPro;

using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

namespace Framework.Editor.PrefabEditor
{
    public static class PrefabUpdater
    {
        public static void UpdateScopePrefab(Object lifetimeScope)
        {

            switch (lifetimeScope)
            {
                case SwitchableMainScope switchableMainScope:
                    UpdateSwitchableMainScopeFields(switchableMainScope);
                    break;

                default:
                    Debug.LogWarning($"Неизвестный тип: {lifetimeScope.GetType()}");
                    break;
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        private static void UpdateSwitchableMainScopeFields(SwitchableMainScope scope)
        {
            if (scope.View != null)
            {
                scope.View.IndustrialFactories.Capacity = 10;

                while (scope.View.IndustrialFactories.Count < scope.View.IndustrialFactories.Capacity)
                {
                    scope.View.IndustrialFactories.Add(new SwitchableMainView.IndustrialFactoryUI());
                }

                var prefabRoot = scope.gameObject;
                Transform[] allTransforms = prefabRoot.GetComponentsInChildren<Transform>();

                for (int i = 0; i < scope.View.IndustrialFactories.Count; i++)
                {
                    GameObject factory = System.Array.Find(allTransforms, t => t.name == $"Factory{i}")?.gameObject;

                    if (factory != null)
                    {
                        Button button = factory.GetComponentInChildren<Button>();
                        TMP_Text text = factory.GetComponentInChildren<TMP_Text>();

                        if (button != null && text != null)
                        {
                            scope.View.IndustrialFactories[i].FactoryButton = button;
                            scope.View.IndustrialFactories[i].FactoryLevelText = text;
                        }
                        else
                        {
                            Debug.LogWarning($"Не удалось найти компоненты в объекте {factory.name}");
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"Не удалось найти объект с именем Factory{i}");
                    }
                }
            }
            else
            {
                Debug.LogWarning("View не инициализирован");
            }
        }
    }
}