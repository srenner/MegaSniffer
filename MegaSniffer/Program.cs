using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MegaSniffer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                Console.WriteLine("Connecting...");
                socket.Connect("192.168.4.1", 8080);
                Console.WriteLine("Connected");
                Console.WriteLine("Press ESC to stop");
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        byte[] buffer = new byte[100];
                        int count = socket.Receive(buffer);
                        string dataString = Encoding.ASCII.GetString(buffer, 0, count);
                        Console.WriteLine(dataString);
                        Console.WriteLine(count);

                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                Console.WriteLine("I'm dead now. Press any key to finish.");
                Console.ReadKey();
                
            }
        }
    }
}
