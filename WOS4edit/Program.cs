using System.Windows.Forms;
using System;

namespace WOS4edit
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(new frmMain());
        }
    }
}
