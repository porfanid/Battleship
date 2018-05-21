using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GetProgress
    {
        String playerName;
        String filename = "";
        FileName createFiles = new FileName();






        public GetProgress(String playerName, String filename)
        {
            this.playerName = playerName;
            this.filename = filename;
        }



        int[,] strikeBoard = new int[10, 10];
        int[,] shipBoard = new int[10, 10];









        public void SaveProgress(int playerTurn, int[,] shipBoard, int[,] strikeBoard)
        {
            writeDataToDisk progress = new writeDataToDisk(filename);
            String Data = playerName + "\n" + playerTurn + "\n" + "\n";
            // print board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Data += shipBoard[i, j].ToString();
                    Data += " ";
                }
                Data += "\n";
            }
            Data += "\n";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Data += strikeBoard[i, j];
                    Data += " ";
                }
                Data += "\n";
            }
            progress.writeData(Data);
        }
    }
}