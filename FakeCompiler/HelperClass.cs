using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace FakeCompiler
{
    internal class HelperClass
    {

        public string CopyTheFile(string sourceFolder, string targetFolder)
        {
            //lmao chatgpt is epic as fuck use it lolllllllllllllllll
            //look this if you are here https://youtu.be/oHAwhZBnI1A


            string newExtension = ".class";

            // Copy the folder and its contents
            Directory.CreateDirectory(targetFolder);
            foreach (string dirPath in Directory.GetDirectories(sourceFolder, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourceFolder, targetFolder));
            foreach (string filePath in Directory.GetFiles(sourceFolder, "*.*", SearchOption.AllDirectories))
            {
                byte[] fileContents = File.ReadAllBytes(filePath);
                string newFilePath = filePath.Replace(sourceFolder, targetFolder);
                File.WriteAllBytes(newFilePath, fileContents);
            }

            // Change the file extensions
            foreach (string filePath in Directory.GetFiles(targetFolder, "*.*", SearchOption.AllDirectories))
            {
                string newFilePath = Path.ChangeExtension(filePath, newExtension);
                File.Move(filePath, newFilePath);
            }

            // Zip the folder
            ZipFile.CreateFromDirectory(targetFolder, targetFolder + ".jar");


            return "Completed.";
        }

        static void CopyFolder(string sourceFolder, string targetFolder)
        {
            // Copy all files in the source folder to the target folder
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string targetPath = Path.Combine(targetFolder, fileName);
                File.Copy(file, targetPath, true); // overwrite existing files
            }

            // Recursively copy all subfolders in the source folder to the target folder
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string folderName = Path.GetFileName(folder);
                string targetPath = Path.Combine(targetFolder, folderName);
                CopyFolder(folder, targetPath); // recursively copy subfolders
            }
        }
    }
}
