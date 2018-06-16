using System;
using System.IO;

namespace Azurlane
{
    internal static class PathMgr
    {
        internal static string Environment(string path = null)
        {
            if (path != null && !Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path == null ? System.Environment.CurrentDirectory : Path.Combine(System.Environment.CurrentDirectory, path);
        }

        internal static string ThirdParty(string path = null) => path != null ? Path.Combine(Environment("Third-party"), path) : Environment("Third-party");
    }
}