using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sdk_lib
{
    class Network
    {
        //回读网络信息
        static public string GetNetworkInfo()
        {
            string cmd = "    <in method=\"GetNetworkInfo\"/>\n";
            return cmd;
        }
    }
}
