using System.IO;

namespace Devices
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using var deviceWriter =
                new StreamWriter("/dev/stdout") {AutoFlush = true};
            using var deviceReader = new StreamReader("/dev/stdout");
            deviceWriter.WriteLine("Wie heißen Sie? ");
            var input = deviceReader.ReadLine();
            deviceWriter.WriteLine($"Hallo {input}");
            deviceReader.Close();
            deviceWriter.Close();
        }
    }
}