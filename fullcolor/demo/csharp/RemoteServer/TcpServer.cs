﻿using System;
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

            IPAddress local = IPAddress.Parse("0.0.0.0");
            IPEndPoint iep = new IPEndPoint(local, this.port_);
            try
            {
                //创建服务器的socket对象
                server_ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server_.Bind(iep);
                server_.Listen(20);
                server_.BeginAccept(new AsyncCallback(Accept), server_);
                this.ShowMessage("Listening port number: " + this.port_ + " success.");
            }
            catch (System.Exception e)
            {
                this.ShowMessage("Listening port number: " + this.port_ + "  failure.");
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
            catch (System.Exception e)
            {
                this.ShowMessage("Listening port number: " + this.port_ + "  failure.");
            }
            SDKClient.GetInstace().InitConnect(client_);
        }
    }
}

