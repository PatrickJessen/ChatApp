using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp
{
    class ChatHandler
    {
        public event EventHandler ReceiveMessage;
        TcpClient clientSocket;
        NetworkStream serverStream;

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                if (value != message)
                {
                    message = value;
                    ReceiveMessages();
                }
            }
        }

        public void ConnectToServer(string ipAdress, int port)
        {
            clientSocket = new TcpClient();

            clientSocket.Connect(ipAdress, port);

            if (null != ReceiveMessage)
                ReceiveMessage(this, EventArgs.Empty);
        }

        public void SendMessage(string message)
        {
            serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(message);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        public string ReceiveMessages()
        {
            EventHandler handler = ReceiveMessage;
            if (handler != null)
            {
                ReceiveMessage(this, EventArgs.Empty);
            }
            byte[] bytesToRead = new byte[clientSocket.ReceiveBufferSize];
            int bytesRead = serverStream.Read(bytesToRead, 0, clientSocket.ReceiveBufferSize);
            string data = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            //clientSocket.Close();

            return data;
        }
    }
}
