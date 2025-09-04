using nanoFramework.Device.Bluetooth.Advertisement;
using ProximityBeacon.Beacons;
using System;
using System.Diagnostics;
using System.Threading;

namespace ProximityBeacon
{
    public class Program
    {
        public static void Main()
        {
            StartBeacon();

            Thread.Sleep(Timeout.Infinite);
        }

        public static void StartBeacon()
        {
            Guid proximityUUID = new Guid("E2C56DB5-DFFB-48D2-B060-D0F5A71096E0");

            Beacon beacon = new Beacon(proximityUUID, 1, 6, -59);

            beacon.Start();

            Thread.Sleep((int)Timeout.Infinite);

            beacon.Stop();
        }
    }
}
