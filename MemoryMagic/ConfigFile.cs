using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MemoryMagic
{
    public static class ConfigFile
    {
        private static string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static void Initialize()
        {
            path = Application.StartupPath + "\\config.ini";
        }

        public static void WriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        public static string ReadValue(string section, string key)
        {
            var temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString().Trim();
        }
    }
}
