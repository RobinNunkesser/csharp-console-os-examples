using System;

namespace ProcessStartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new ProcessManager().StartProcess("ls", "/",
                true);
            p.WaitForExit();
        }
    }
}