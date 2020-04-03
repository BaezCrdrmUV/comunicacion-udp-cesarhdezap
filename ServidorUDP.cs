using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace comunicacion_udp
{
    public class ServidorUDP
    {
        //private Socket socket;
        //private IPEndPoint IP;

        private UdpClient udpClient = new UdpClient(11000);
        public ServidorUDP(string ipServer, int puertoServer) 
        {
            //socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //IPAddress broadcast = IPAddress.Parse(ipServer);
            //IP = new IPEndPoint(broadcast, 11000);
            udpClient.Connect(ipServer, puertoServer);
        }

        public void EnviarMensaje(string mensaje)
        {
            //Byte[] sendbuf = Encoding.ASCII.GetBytes(mensaje);
            //socket.SendTo(sendbuf, IP);
            Byte[] sendBytes = Encoding.ASCII.GetBytes(mensaje);
      
            udpClient.Send(sendBytes, sendBytes.Length);
            
            Console.WriteLine("Mensaje enviado: {0}", mensaje); 
        }
    }
}