using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer
{
    class Program
    {   // Main Method 

        static Random rm = new Random();
        static void Main(string[] args)
        {

            // Establish the local endpoint 
            // for the socket. Dns.GetHostName 
            // returns the name of the host 
            // running the application. 
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            //Ip address parse
            IPAddress ipAddr = IPAddress.Parse("192.168.1.103");
            //Port details
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 4242);

            // Creation TCP/IP Socket using 
            // Socket Class Costructor 
            Socket listener = new Socket(ipAddr.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);

            try
            {

                // Using Bind() method we associate a 
                // network address to the Server Socket 
                // All client that will connect to this 
                // Server Socket must know this network 
                // Address 
                listener.Bind(localEndPoint);

                // Using Listen() method we create 
                // the Client list that will want 
                // to connect to Server 
                listener.Listen(10);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");

                    // Suspend while waiting for 
                    // incoming connection Using 
                    // Accept() method the server 
                    // will accept connection of client 
                    Socket clientSocket = listener.Accept();

                    // Data buffer 
                    byte[] bytes = new Byte[8];
                    string data = null;

                    //while (true)
                    //{

                    //int numByte = clientSocket.Receive(bytes);
                    //Console.WriteLine(BitConverter.ToString(bytes));
                    // data += numByte; /*Encoding.ASCII.GetString(bytes,0, numByte);*/

                    // if (data.IndexOf("18") > -1)
                    // break;
                    //}
                    while (clientSocket.Connected)
                    {
                        byte[] message = new byte[] { 0xAA, 0xc1, 0x10, 0x10, 0x11, 0x20, 0x21, 0x22, 0x11, 0x15, 0x12, 0x42, 0x48, 0x12, 0x10, 0x42, 0x05, 0x02, 0x48, 0xCC, 0xEE };
                        // Console.WriteLine(encode);
                        // Send a message to Client 
                        // using Send() method 
                        clientSocket.Send(message);
                        Console.WriteLine("sent data");
                        //System.Threading.Thread.Sleep(1000);
                    }
                    // Close client Socket using the 
                    // Close() method. After closing, 
                    // we can use the closed Socket 
                    // for a new Client Connection 
                    // clientSocket.Shutdown(SocketShutdown.Both);
                    //clientSocket.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }

       
    }
}
