using System;
using System.IO;
using System.Text;
using System.Security.AccessControl;
namespace ConsoleApp1
{
    class writeDataToDisk
    {


        string filename;
        



        public writeDataToDisk(String filename)
        {
            this.filename = filename;
        }





        







        public void writeData(String data)
        {
            FileName createFiles = new FileName();
            string ending = createFiles.Ending();
            string path = createFiles.saveProgressPath();
            string file = path+"//"+filename + "." + ending;
            // This text is added only once to the file.
            // Create a file to write to.
            // System.IO.Directory.CreateDirectory(path);












            //string createText = "Hello and Welcome" + Environment.NewLine;

            if (!File.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            File.WriteAllText(file, data);
            // Open the file to read from.
            //   string readText = File.ReadAllText(file);
            //   Console.WriteLine(readText);
        }
    }
}
