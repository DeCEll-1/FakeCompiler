using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FakeCompiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://asciiflow.com/#/ for making the ascii menu

            Console.WriteLine("+---------------------------------------------------------------------------------------+\r\n| Welcome to the Fake Compiler.                                                         |\r\n|                                                                                       |\r\n| Due to the limitations of \"security\" this app has opened a file in your C:\\ directory.|\r\n|                                                                                       |\r\n| Please copy paste your scr folders content to the \"C:\\FakeComp\\Source\" directory.     |\r\n|                                                                                       |\r\n| The \"jar\" folder that appears in the \"C:\\FakeComp\" can be ignored.                    |\r\n|                                                                                       |\r\n| the \"C:\\FakeComp\" file will be deleted when you reopen this app.                      |\r\n|                                                                                       |\r\n| Made by DeCell#7556 with THE FUCKING HATE OF INTELLIJS COMPILER                       |\r\n|                                                                                       |\r\n+---------------------------------------------------------------------------------------+");

            DirectoryInfo dimain = new DirectoryInfo("C:\\FakeComp");

            DirectoryInfo disrc = new DirectoryInfo("C:\\FakeComp\\Source");


            if (!dimain.Exists)
            {
                dimain.Create();

                disrc.Create();
            }
            else
            {
                dimain.Delete(true);

                dimain.Create();

                disrc.Create();
            }
            if (!disrc.Exists)
            {
                disrc.Create();
            }

            string srcpath = "C:\\FakeComp\\Source";

            string targetpath = "C:\\FakeComp\\jar";

            Console.WriteLine("/!\\ be sure that you putten your src to the said folder.");

            Console.WriteLine("Press enter to proceed");

            Console.ReadLine();

            Console.WriteLine(new HelperClass().CopyTheFile(srcpath, targetpath));

            Console.WriteLine("Press enter to close the app");

            Console.ReadLine();

        }
    }
}
