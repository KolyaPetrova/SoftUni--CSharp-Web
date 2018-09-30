﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P3.SimpleWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = IPAddress.Parse("127.0.0.1");
            int port = 1300;

            var listener = new TcpListener(address, port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at {address}:{port}");

            var task = Task.Run(() => ConnectWithTcpClient(listener));
            task.Wait();
        }

        public static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");

                TcpClient client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected.");

                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, buffer.Length);

                string message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(message);

                byte[] data = Encoding.ASCII.GetBytes("Hello from server!");
                client.GetStream().Write(data, 0, data.Length);

                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }
        }
    }
}
