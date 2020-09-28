namespace huidu.sdk
{
    public class XmlCmd
    {
        static string header =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
            + "<sdk guid=\"##GUID\">\n";
        static string end = "</sdk>\n";

        //Read back brightness strategy
        static public string GetLuminancePloy()
        {
            string cmd = header + Light.GetLuminancePloy() + end;
            return cmd;
        }

        //Set brightness strategy
        static public string SetLuminancePloy()
        {
            string cmd = header + Light.SetLuminancePloy() + end;
            return cmd;
        }

        //Readback time correction
        public static string GetTimeInfo()
        {
            string cmd = header + AdjustTime.GetTimeInfo() + end;
            return cmd;
        }

        //Set time correction
        public static string SetTimeInfo()
        {
            string cmd = header + AdjustTime.SetTimeInfo() + end;
            return cmd;
        }

        //Read back switch screen
        public static string GetSwitchTime()
        {
            string cmd = header + SwitchScreen.GetSwitchTime() + end;
            return cmd;
        }

        //Set switch screen
        public static string SetSwitchTime()
        {
            string cmd = header + SwitchScreen.SetSwitchTime() + end;
            return cmd;
        }

        //Read back multimedia file list
        public static string GetFiles()
        {
            string cmd = header + FileServices.GetFiles() + end;
            return cmd;
        }

        //Set HDPlayer FPGA configuration parameters
        public static string SetHDPlayerFPGAConfig(string xml)
        {
            string cmd = header + HwSetting.SetHDPlayerFPGAConfig(xml) + end;
            return cmd;
        }

        //Set SDK FPGA configuration parameters
        public static string SetSDKFPGAConfig(string xml)
        {
            string cmd = header + HwSetting.SetSDKFPGAConfig(xml) + end;
            return cmd;
        }

        //Read back SDK FPGA configuration parameters
        public static string GetSDKFPGAConfig()
        {
            string cmd = header + HwSetting.GetSDKFPGAConfig() + end;
            return cmd;
        }

        //Read back network information
        public static string GetNetworkInfo()
        {
            string cmd = header + Network.GetNetworkInfo() + end;
            return cmd;
        }
    }
}
