using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelLab
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
             //Application.Run(new formShowImg());
            //Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formShowImg());
            //Console.WriteLine(Environment.Is64BitProcess);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ThreeDForm());
        }
    }
}
