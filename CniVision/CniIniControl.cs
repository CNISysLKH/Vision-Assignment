using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;

namespace CniVision
{
    /// <summary>
    /// 시스템 설정 변수들
    /// </summary>
    public struct SystemConfig
    {
        /// <summary>
        /// 이미지 저장 경로
        /// </summary>
        public string SaveImageDirectory { get; set; }
        /// <summary>
        /// 결과 데이터 저장 경로
        /// </summary>
        public string SaveDataDirectory { get; set; }
        /// <summary>
        /// 원본 이미지 저장 여부
        /// </summary>
        public bool IsSaveOriginImage { get; set; }
        /// <summary>
        /// 결과 이미지 저장 여부
        /// </summary>
        public bool IsSaveResultImage { get; set; }
        /// <summary>
        /// CSV 형식 결과 데이터 저장 여부
        /// </summary>
        public bool IsSaveCSV { get; set; }
        /// <summary>
        /// TXT 형식 결과 데이터 저장 여부
        /// </summary>
        public bool IsSaveTXT { get; set; }
    }

    public class CniIniControl 
    {
        private static readonly string iniPath = Application.StartupPath + @"\Config.ini";

        public static void CheckAndCreateIniFile()
        {
            if (!File.Exists(iniPath))
            {
                CniIniDllImport.IniWriteValue("SYSTEM", "Image_Directory", Application.StartupPath);
                CniIniDllImport.IniWriteValue("SYSTEM", "Data_Directory", Application.StartupPath);
                CniIniDllImport.IniWriteValue("SYSTEM", "Origin_Image", false.ToString());
                CniIniDllImport.IniWriteValue("SYSTEM", "Result_Image", false.ToString());
                CniIniDllImport.IniWriteValue("SYSTEM", "CSV", false.ToString());
                CniIniDllImport.IniWriteValue("SYSTEM", "TXT", false.ToString());

                CniIniDllImport.IniWriteValue("CAMERA", "", "");

                CniIniDllImport.IniWriteValue("INPUTSIGNAL", "Trigger_Enable", "");
                CniIniDllImport.IniWriteValue("INPUTSIGNAL", "Polarity", "");
                CniIniDllImport.IniWriteValue("INPUTSIGNAL", "Debounce_Time", "");

                CniIniDllImport.IniWriteValue("OUTPUTSIGNAL", "Read_Enable", "");
                CniIniDllImport.IniWriteValue("OUTPUTSIGNAL", "NoRead_Enable", "");
                CniIniDllImport.IniWriteValue("OUTPUTSIGNAL", "Action", "");
                CniIniDllImport.IniWriteValue("OUTPUTSIGNAL", "Pulse_Width", "");

            }
        }


    }

    public static class CniIniDllImport
    {
        private static readonly string iniPath = Application.StartupPath + @"\Config.ini";

        [DllImport("kernel32")]
        private static extern uint GetPrivateProfileString(

            string lpAppName, // points to section name 
            string lpKeyName, // points to key name 
            string lpDefault, // points to default string 
            byte[] lpReturnedString, // points to destination buffer 
            uint nSize, // size of destination buffer 
            string lpFileName  // points to initialization filename 
        );

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(   // INI Read
            string section,
            string key,
            string def,
            StringBuilder retVal,
            int size,
            string filePath);

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString( // INI Write
            string section,
            string key,
            string val,
            string filePath);

        // INI File Read
        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, iniPath);
            return temp.ToString();
        }

        public static string IniReadValue(string Section, string Key, string sPath)
        {

            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, sPath);
            return temp.ToString();
        }

        // INI File Write
        public static void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, iniPath);
        }

        public static void IniWriteValue(string Section, string Key, string Value, string sPath)
        {
            WritePrivateProfileString(Section, Key, Value, sPath);
        }

        //Section Count
        public static List<string> ReadSection(string sPath)
        {
            List<string> result = new List<string>();

            byte[] buf = new byte[65536];
            uint len = GetPrivateProfileString(null, null, null, buf, (uint)buf.Length, sPath);
            int j = 0;

            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            }
            return result;
        }
    }

}
