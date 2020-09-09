using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;

namespace AnonymousPipe
{
    class Program
    {
        static void Main(string[] args)
        {
            using var pipeServer = new AnonymousPipeServerStream(PipeDirection.Out,
                HandleInheritability.Inheritable);
            using var pipeClient = new AnonymousPipeClientStream(PipeDirection.In,
                pipeServer.ClientSafePipeHandle);
            try
            {
                using var sw = new StreamWriter(pipeServer) {AutoFlush = true};
                sw.WriteLine("Hello world through a pipe!");
                using var sr = new StreamReader(pipeClient);
                var received = sr.ReadLine();
                Console.WriteLine($"Received: {received}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                pipeServer.Dispose();
                pipeClient.Dispose();
            }
        }

    }
}