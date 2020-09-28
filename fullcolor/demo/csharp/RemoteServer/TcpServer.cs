using System;
using System.Net;
using System.Net.Sockets;

namespace huidu.sdk
{
    public delegate void ShowMessageHandle(string msg, bool error);
    public class TcpServer
    {
        private int port_;
        private Socket server_;
        private Socket client_;
        public ShowMessageHandle showMsgHandle_ = null;
        private static TcpServer instance_ = null;
        public static TcpServer GetInstance()
        {
            if (instance_ == null)
            {
                instance_ = new TcpServer();
            }

            return instance_;
        }

        private TcpServer()
        {
            this.port_ = 0;
        }

        public Socket GetClient()
        {
            return this.client_;
        }

        public void ShowMessage(string msg, bool error = true)
        {
            if (this.showMsgHandle_ != null)
            {
                this.showMsgHandle_(msg, error);
            }
        }

        public void InitListen(int port)
        {
            this.port_ = port;
            IPAddress local = IPAddress.Parse("169.254.222.129");
            IPEndPoint iep = new IPEndPoint(local, this.port_);
            try
            {
                //Create a socket object for the server
                server_ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server_.Bind(iep);
                server_.Listen(20);
                server_.BeginAccept(new AsyncCallback(Accept), server_);
                this.ShowMessage($"Listening port number: {this.port_ } success.");
            }
            catch (Exception e)
            {
                this.ShowMessage($"Listening port number: {this.port_} failure. {e.Message}");
            }
        }

        private void Accept(IAsyncResult iar)
        {
            if (this.client_ != null)
            {
                this.client_.Close();
                this.client_ = null;
            }

            this.client_ = this.server_.EndAccept(iar);
            this.ShowMessage("One client access.");
            try
            {
                server_.BeginAccept(new AsyncCallback(Accept), server_);
            }
            catch (Exception e)
            {
                this.ShowMessage($"Listening port number: {this.port_} failure. {e.Message}");
            }
            SDKClient.GetInstace().InitConnect(client_);
        }
    }
}