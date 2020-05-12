using System;
using System.Diagnostics;
    public static class ShellHelper
    {
        public static string Bash(string cmd,string filename)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @filename,
                    Arguments = cmd,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }