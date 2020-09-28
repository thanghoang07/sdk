using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace huidu.sdk
{
    class AdjustTime
    {
        //Readback time correction
        public static string GetTimeInfo()
        {
            string cmd = "    <in method=\"GetTimeInfo\"/>";
            return cmd;
        }

        //Set time correction
        public static string SetTimeInfo()
        {
            string cmd =
                  "    <in method=\"SetTimeInfo\">\n"
                + "        <timezone value=\"(UTC+08:00)Beijing,Chongqing,HongKong,Urumchi\"/>\n"
                + "        <summer enable=\"false\"/>\n"
                + "        <sync value=\"none\"/>\n"
                + "        <time value=\"2017-09-06 08:11:06\"/>\n"
                + "    </in>\n";
            return cmd;
        }
    }
}
