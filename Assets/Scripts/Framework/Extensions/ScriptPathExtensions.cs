namespace Framework.Extensions
{
    public static class ScriptAssetExtensions
    {
        public static string GetNamespaceFromPath(this string directoryPath) =>
             directoryPath.Replace("Assets\\", "").Replace("Scripts\\", "").Replace("\\", ".");
    }
}