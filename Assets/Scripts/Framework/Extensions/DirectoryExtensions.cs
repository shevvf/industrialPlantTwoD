using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Framework.Extensions
{
    public static class DirectoryExtensions
    {
        public static List<string> GetFiles(this string scriptsDirectory, string extension, SearchOption searchOption = SearchOption.AllDirectories)
        {
            string extensionName = string.Join("", "*", extension);
            return Directory.GetFiles(scriptsDirectory, extensionName, searchOption).ToList();
        }
    }
}