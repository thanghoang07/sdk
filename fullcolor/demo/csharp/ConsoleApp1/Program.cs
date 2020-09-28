using huidu.sdk;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Initialize the socket listener, start the thread for socket monitoring
            SocketHelper.GetInstance().Init();
            //Create udp service: support search control card, set control card IP address
            UDPServices.GetInstance();
            UDPServices.GetInstance().xmlRespond_ += XmlRespond;
            //
            HDeviceInfo[] devices = UDPServices.GetInstance().GetDevices();
            Console.WriteLine($"Hello World! {devices.FirstOrDefault().id}");
        }

        private static void XmlRespond(byte[] buffer, int len)
        {
            
        }
    }
}
