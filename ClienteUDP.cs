using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace comunicacion_udp
{
    public class ClienteUDP
    {
        private IPEndPoint IP;
        private UdpClient listener;

        public ClienteUDP(string ip, int puerto)
        {
            IPAddress address = IPAddress.Parse(ip);
            IP = new IPEndPoint(address, puerto);
            listener = new UdpClient(puerto);
            
        }

        public void Escuchar()
        {
            try
            {
                string mensaje = string.Empty;
                while (mensaje != "bye")
                {
                    Console.WriteLine("Esperando mensaje del servidor...");

                    byte[] bytes = listener.Receive(ref IP);
                    mensaje = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine($"Mensaje recibido de {IP} :");
                    Console.WriteLine(mensaje);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }
    }
    
}
