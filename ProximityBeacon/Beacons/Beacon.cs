using System;
using nanoFramework.Device.Bluetooth;
using nanoFramework.Device.Bluetooth.Advertisement;

namespace ProximityBeacon.Beacons
{
    public class Beacon
    {
        private Guid _proximityUuid;
        private ushort _major;
        private ushort _minor;
        private sbyte _txPower;

        private BluetoothLEAdvertisementPublisher _publisher;

        public Beacon(Guid ProximityUuid, ushort major, ushort minor, sbyte txPower)
        {
            _proximityUuid = ProximityUuid;
            _major = major;
            _minor = minor;
            _txPower = txPower;
            _publisher = null;
        }

        public Guid ProximityUuid { get => _proximityUuid; set => _proximityUuid = value; }

        public ushort Major { get => _major; set => _major = value; }

        public ushort Minor { get => _minor; set => _minor = value; }

        public void Start()
        {
            _publisher = new BluetoothLEAdvertisementPublisher();

            _publisher.Advertisement.Flags = BluetoothLEAdvertisementFlags.GeneralDiscoverableMode |
                                             BluetoothLEAdvertisementFlags.DualModeControllerCapable |
                                             BluetoothLEAdvertisementFlags.DualModeHostCapable;


            BluetoothLEManufacturerData manufacturerData = new BluetoothLEManufacturerData();

            manufacturerData.CompanyId = 0x004c;

            DataWriter writer = new();

            writer.WriteBytes(new byte[] { 0x02, 0x15 });

            writer.WriteUuid2(ProximityUuid);
            writer.WriteByte((byte)(_major / 256));
            writer.WriteByte((byte)(_major & 0xff));
            writer.WriteByte((byte)(_minor / 256));
            writer.WriteByte((byte)(_minor & 0xff));

            writer.WriteByte((byte)_txPower);

            manufacturerData.Data = writer.DetachBuffer();

            _publisher.Advertisement.ManufacturerData.Add(manufacturerData);
            _publisher.Start();
        }

        public void Stop()
        {
            _publisher?.Stop();
            _publisher = null;
        }
    }
}
