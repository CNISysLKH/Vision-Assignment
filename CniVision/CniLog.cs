using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CniVision
{
    public class CniLog
    {
        public static void WriteLog(string sLog)
        {
            try
            {
                string sFilePath = System.Windows.Forms.Application.StartupPath + @"\Log\System Log\";
                string sFilName = sFilePath + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";

                if (!Directory.Exists(sFilePath))
                    Directory.CreateDirectory(sFilePath);

                StreamWriter sw = new StreamWriter(sFilName, true, Encoding.Default);

                sw.Write(DateTime.Now.ToString("[yyyy_MM_dd HH:mm:ss]") + "   " + sLog + "\r\n");
                sw.Close();
            }
            catch (Exception)
            {

            }
        }

        public static void WriteLog(Exception ex)
        {
            try
            {
                string sFilePath = System.Windows.Forms.Application.StartupPath + @"\Log\System Log\";
                string sFilName = sFilePath + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";

                if (!Directory.Exists(sFilePath))
                    Directory.CreateDirectory(sFilePath);

                StreamWriter sw = new StreamWriter(sFilName, true, Encoding.Default);

                sw.Write($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Data : {ex.Data}");
                sw.Write($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Message : {ex.Message}");
                sw.Write($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Source : {ex.Source}");
                sw.Write($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] StackTrace : {ex.StackTrace}");
                sw.Close();
            }
            catch (Exception)
            {

            }

        }
    }
}
