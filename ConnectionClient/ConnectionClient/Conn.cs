using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CC
{
    public class Conn
    {
        public static string Get(string thing)
        {
            return SendString(string.Concat("get ", thing, "\n"));
        }

        public static string Set(string thing, int value)
        {
            return SendString(string.Concat("set ", thing, " ", value, "\n"));
        }
        
        /// <summary>
        /// Send a string to the server.
        /// </summary>
        /// <param name="s">The string to send.</param>
        /// <returns>The response of the server.</returns>
        private static string SendString(string s)
        {
            var bytes = new byte[1024];

            var ipAddress = IPAddress.Parse("172.16.6.0");
            var remoteEndPoint = new IPEndPoint(ipAddress, 2525);

            var sender = new Socket(
                ipAddress.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);

            var msg = Encoding.ASCII.GetBytes(s);

            try
            {
                sender.Connect(remoteEndPoint);
            } catch(ArgumentNullException ae) {  
                return ae.ToString();  
            } catch(SocketException se) {  
                return se.ToString();
            } catch(Exception e) {
                return e.ToString();
            }  

            sender.Send(msg);

            var bytesReceived = sender.Receive(bytes);

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            return Encoding.ASCII.GetString(bytes, 0, bytesReceived);
        }
    }
}
