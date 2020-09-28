namespace huidu.sdk
{
    public class Light
    {
        //Read back brightness strategy
        static public string GetLuminancePloy()
        {
            string cmd = "    <in method=\"GetLuminancePloy\"/>\n";
            return cmd;
        }

        //Set brightness strategy
        static public string SetLuminancePloy()
        {
            string cmd = ""
                + "    <in method=\"SetLuminancePloy\">\n"
                + "        <mode value=\"##mode\"/>\n"
                + "        <default value=\"80\"/>\n"
                + "        <sensor min=\"1\" max=\"100\" time=\"5\"/>\n"
                + "        <ploy>\n"
                + "            <item enable=\"true\" start=\"00:00:00\" percent=\"1\"/>\n"
                + "            <item enable=\"true\" start=\"03:00:00\" percent=\"22\"/>\n"
                + "            <item enable=\"true\" start=\"06:00:00\" percent=\"100\"/>\n"
                + "        </ploy>\n"
                + "    </in>\n";

            cmd = cmd.Replace("##mode", "default"); //默认模式
            //cmd = cmd.Replace("##mode", "ploys");   //自定义模式
            //cmd = cmd.Replace("##mode", "sensor");  //传感器模式
            return cmd;
        }
    }
}
