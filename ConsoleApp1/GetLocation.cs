using System;
using System.Device.Location;
//using System.Device.*;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GetLocation
    {
        public void GetLocationProperty()
        {
            Console.WriteLine("UserName: {0}", Environment.UserName);
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
            watcher.Start();
            GeoCoordinate coord = watcher.Position.Location;

            if (!coord.IsUnknown)
            {
                Console.WriteLine("Lat: {0}, Long: {1}",
                    coord.Latitude,
                    coord.Longitude);
            }
            else
            {
                Console.WriteLine("Unknown latitude and longitude.");
            }
        }
    }
}
