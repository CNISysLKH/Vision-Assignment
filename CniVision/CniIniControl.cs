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
    public static class CniIniControl
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

    // Ini File 변수 및 조작
    public static class CniIniArguments
    {
        private static string _SaveImageDirectory;
        private static string _SaveDataDirectory;
        private static bool _IsSaveOriginImage;
        private static bool _IsSaveResultImage;
        private static bool _IsSaveCSV;
        private static bool _IsSaveTXT;
        public static string SaveImageDirectory
        {
            get
            {
                return _SaveImageDirectory;
            }
            set
            {
                _SaveImageDirectory = value;
                CniIniControl.IniWriteValue("PROGRAM", "SAVE_IMAGE_PATH", _SaveImageDirectory);

            }
        }
        public static string SaveDataDirectory
        {
            get
            {
                return _SaveDataDirectory;
            }
            set
            {
                _SaveDataDirectory = value;
                CniIniControl.IniWriteValue("PROGRAM", "SAVE_DATA_PATH", _SaveDataDirectory);

            }
        }
        public static bool IsSaveOriginImage
        {
            get
            {
                return _IsSaveOriginImage;
            }
            set
            {
                _IsSaveOriginImage = value;
                CniIniControl.IniWriteValue("PROGRAM", "SAVE_ORIGIN_IMAGE", _IsSaveOriginImage.ToString());
            }
        }
        public static bool IsSaveResultImage
        {
            get
            {
                return _IsSaveResultImage;
            }
            set
            {
                _IsSaveResultImage = value;
                CniIniControl.IniWriteValue("PROGRAM", "SAVE_RESULT_IMAGE", _IsSaveResultImage.ToString());
            }
        }
        public static bool IsSaveCSV
        {
            get
            {
                return _IsSaveCSV;
            }
            set
            {
                _IsSaveCSV = value;
                CniIniControl.IniWriteValue("PROGRAM", "SAVE_CSV", _IsSaveCSV.ToString());

            }
        }
        public static bool IsSaveTXT
        {
            get
            {
                return _IsSaveTXT;
            }
            set
            {
                _IsSaveTXT = value;
                CniIniControl.IniWriteValue("PROGRAM", "SAVE_TXT", _IsSaveTXT.ToString());
            }
        }

        static CniIniArguments()
        {
            _SaveImageDirectory = CniIniControl.IniReadValue("PROGRAM", "SAVE_IMAGE_PATH");
            _SaveDataDirectory = CniIniControl.IniReadValue("PROGRAM", "SAVE_DATA_PATH");
            _IsSaveOriginImage = bool.Parse(CniIniControl.IniReadValue("PROGRAM", "SAVE_ORIGIN_IMAGE"));
            _IsSaveResultImage = bool.Parse(CniIniControl.IniReadValue("PROGRAM", "SAVE_RESULT_IMAGE"));
            _IsSaveCSV = bool.Parse(CniIniControl.IniReadValue("PROGRAM", "SAVE_CSV"));
            _IsSaveTXT = bool.Parse(CniIniControl.IniReadValue("PROGRAM", "SAVE_TXT"));
        }




    }
}
