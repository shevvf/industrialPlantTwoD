#if UNITY_EDITOR

using System.IO;

using UnityEditor.VersionControl;

using UnityEngine;

namespace Framework.Extensions
{
    public static class PathExtensions
    {
        public static string GetPathFromMeta(this string metaPath)
        {
            Asset asset = new(metaPath);
            return asset.isMeta ? asset.assetPath : null;
        }

        public static string GetExtensionName(this string path, string extension)
        {
            string extensionName = Path.GetExtension(path);
            return extensionName == extension ? extensionName : null;
        }

        public static string GetDirectoryName(this string path)
        {
            return Path.GetDirectoryName(path);
        }

        public static string GetClassName(this string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public static string CombineWithAppDataPath(this string path)
        {
            return Path.Combine(Application.dataPath, path);
        }
    }
}
#endif