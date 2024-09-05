using UnityEngine;

namespace IndustrialPlant.Infrastructure.Factories.BaseFactory
{
    public interface IFactory
    {
        GameObject CreatePrefab(GameObject prefab, Transform parent);
    }
}