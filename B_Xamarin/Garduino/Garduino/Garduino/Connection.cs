using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Garduino
{
    class Connection
    {
        Socket _connectionSocket;
        private IPAddress ipAddress;
        private readonly IPEndPoint remoteEP;
        private readonly byte[] bytes = new byte[2048];

        public Connection()
        {
            try
            {
                ipAddress = IPAddress.Parse("192.168.1.6");
                remoteEP = new IPEndPoint(ipAddress, 12345);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void OpenConnection()
        {
            _connectionSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _connectionSocket.Connect(remoteEP);
        }
        public void CloseConnection()
        {
            _connectionSocket.Shutdown(SocketShutdown.Both);
            _connectionSocket.Close();
        }
        public void Send(string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            _connectionSocket.Send(msg);
        }

        public string Recieve(string message)
        {
            Send(message);
            int byteRec = _connectionSocket.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, byteRec);
        }

    }
}
