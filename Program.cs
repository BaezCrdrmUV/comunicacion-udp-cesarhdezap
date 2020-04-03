using System;

namespace comunicacion_udp
{
    class Program
    {
        static void Main(string[] args)
        {
            string IP_SERVER = "127.0.0.1";
            int PUERTO_SERVER = 8080;

            Console.WriteLine("Iniciando...");
            Console.WriteLine("Escriba: server o cliente");
            string respuesta = Console.ReadLine();


            if(respuesta == "cliente")
            {
                ClienteUDP cliente = new ClienteUDP(IP_SERVER,PUERTO_SERVER);
                cliente.Escuchar();
            } 
            else if(respuesta == "server")
            {

                ServidorUDP server = new ServidorUDP(IP_SERVER, PUERTO_SERVER);
                

                Console.WriteLine("Escriba el mensaje a enviar (escriba salir para terminar): ");
                string mensaje = string.Empty;

                while(mensaje != "salir") 
                {
                    mensaje = Console.ReadLine();
                    server.EnviarMensaje(mensaje);
                }

                server.EnviarMensaje("bye");
            }
        }
    }
}
