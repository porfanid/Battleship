using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using WMPLib;
using System.Media;

namespace ConsoleApp1
{
    class MusicPlayer
    {
        private void wait(int milliseconts)
        {
            try
            {
                System.Threading.Thread.Sleep(milliseconts);
            }
            catch (Exception)
            {

            }
        }
        public void GetMp3()
        {
            FileName name = new FileName();
            string Path = name.musicPath();
            string extension = name.Ending();
            SoundPlayer player = new SoundPlayer(Path+"\\"+"file"+"."+extension);
            player.Play();
            wait(3000);
         //   player = new SoundPlayer(Path+"\\"+"file"+"."+extension);
         //   player.PlayLooping();
        }
    }
}