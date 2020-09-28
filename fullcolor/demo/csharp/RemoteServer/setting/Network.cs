using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace huidu.sdk
{
    class Network
    {
        //Read back network information
        static public string GetNetworkInfo()
        {
            string cmd = "    <in method=\"GetNetworkInfo\"/>\n";
            return cmd;
        }
    }
}
