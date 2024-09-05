using System;
using System.Collections.Generic;

using UnityEngine;

namespace Framework.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }

        public static T FromJson<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }

        public static List<T> FromJsonList<T>(this string json)
        {
            string wrappedJson = $"{{\"items\":{json}}}";
            WrapperList<T> wrapper = JsonUtility.FromJson<WrapperList<T>>(wrappedJson);
            return wrapper.items;
        }
    }

    [Serializable]
    public class WrapperList<T>
    {
        public List<T> items;
    }
}