using UnityEngine;

namespace IndustrialPlant.Infrastructure.Factories.BaseFactory
{
    public class Factory : IFactory
    {
        public GameObject CreatePrefab(GameObject prefab, Transform parent)
        {
            return Object.Instantiate(prefab, parent);
        }
    }
}