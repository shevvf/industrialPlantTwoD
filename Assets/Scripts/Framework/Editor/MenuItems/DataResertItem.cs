using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Framework.Editor.MenuItems
{
    public class DataResertItem
    {
        [MenuItem(MenuItemPath.DATA_RESERT_PATH)]
        public static void ResetDataEditor()
        {
            string path = $"{Application.persistentDataPath}/Json";
            foreach (string directory in Directory.GetDirectories(path))
            {
                try
                {
                    Directory.Delete(directory, true);
                }
                catch (IOException)
                {
                    Directory.Delete(directory, true);
                }
                catch (UnauthorizedAccessException)
                {
                    Directory.Delete(directory, true);
                }
            }
            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }
    }
}