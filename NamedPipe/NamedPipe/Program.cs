using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace NamedPipe
{
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Text to send: ");
            Console.WriteLine("Received: ");
            StartServer();
            Task.Delay(1000).Wait();
            
            //Client
            var client = new NamedPipeClientStream("PipeName");
            client.Connect();
            var writer = new StreamWriter(client);

            while (true)
            {
                Console.SetCursorPosition(14,1);
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                writer.WriteLine(input);
                writer.Flush();
            }
        }

        private static void StartServer()
        {
            Task.Factory.StartNew(() =>
            {
                var server = new NamedPipeServerStream("PipeName");
                server.WaitForConnection();
                var reader = new StreamReader(server);
                while (true)
                {
                    var line = reader.ReadLine();
                    Console.SetCursorPosition(14,2);
                    Console.WriteLine(line);
                    Console.SetCursorPosition(14,1);
                }
            });
        }
    }

}