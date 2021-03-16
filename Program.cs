using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Test_client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string address = "127.0.0.1";
                int port = 8001;

                Console.WriteLine("Ansluter...");
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(address, port);
                Console.WriteLine("Ansluten!");

                Console.WriteLine("Skriv in meddelande: ");
                string message = Console.ReadLine();

                Byte[] bMessage = System.Text.Encoding.ASCII.GetBytes(message);

                Console.WriteLine("Skickar...");
                NetworkStream tcpStream = tcpClient.GetStream();
                tcpStream.Write(bMessage, 0, bMessage.Length);

                byte[] bRead = new byte[256];
                int bReadSize = tcpStream.Read(bRead, 0, bRead.Length);

                string read = "";
                for (int i = 0; i < bReadSize; i++)
                    read += Convert.ToChar(bRead[i]);
                Console.WriteLine("Servern säger: " + read);

                tcpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

        }
    }
}
