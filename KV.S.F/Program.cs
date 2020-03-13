using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KV.S.F
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(GetForm());
        }
        public static Form GetForm() {
            Assembly assembly = Assembly.LoadFile(@"D:\KV_Project\KV\KV.S.F\bin\Debug\KV.S.F.exe"); // 加载程序集（EXE 或 DLL） 
            object obj = assembly.CreateInstance("KV.S.F.Form2"); // 创建类的实例 
            return (Form)obj;
        }
    }
}
