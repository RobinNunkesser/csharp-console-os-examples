using System.Diagnostics;

namespace ProcessStartExample
{
    public class ProcessManager
    {
        public Process StartProcess(string command, string args, bool showWindow)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(command, args)
                {
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    UseShellExecute = false,
                    CreateNoWindow = !showWindow
                }
            };
            p.Start();

            return p;
        }
    }
}