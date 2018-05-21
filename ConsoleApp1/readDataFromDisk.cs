using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class readDataFromDisk
    {
        string file;
        string[] lines;

        public  void getContent()
        {
            string filename = "paul";
            FileName createFiles = new FileName();
            string ending = createFiles.Ending();
            string path = createFiles.saveProgressPath();
            file = path + "//" + filename + "." + ending;
            lines = System.IO.File.ReadAllLines(file);
        }








        public String playerName()
        {
            string playername = lines[0];
            return playername;
        }








        public int playerTurn()
        {
            return Int32.Parse(lines[1]);
        }









        public int[,] ShipBoard()
        {
            int[,] shipBoard = new int[10,10];
            for (int i=2;i<12;i++)
            {
                string[] row = lines[i].Split();

                for (int j = 0; j < 10; i++)
                {
                    shipBoard[i,j]= Int32.Parse(row[j]);
                }
            }
            return shipBoard; 
        }








        public int[,] StrikeBoard()
        {
            int[,] shipBoard = new int[10, 10];
            for (int i = 12; i < 22; i++)
            {
                string[] row = lines[i].Split();

                for (int j = 0; j < 10; i++)
                {
                    shipBoard[i, j] = Int32.Parse(row[j]);
                }
            }
            return shipBoard;
        }
    }
}
