using System;
using System.Diagnostics;

namespace Azurlane
{
    internal static class Utils
    {
        internal static void Command(string argument)
        {
            var process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = $"/c {argument}";
            process.StartInfo.WorkingDirectory = PathMgr.Thirdparty();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.WaitForExit();
            process.Close();
        }
    }
}