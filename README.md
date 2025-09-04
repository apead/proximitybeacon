# ProximityBeacon

A .NET nanoFramework application that creates a Bluetooth Low Energy (BLE) proximity beacon using the iBeacon protocol.

## Overview

ProximityBeacon is a lightweight IoT application built with .NET nanoFramework that transforms your device into a BLE beacon. The application broadcasts iBeacon-compatible advertisements that can be detected by mobile apps and other BLE-enabled devices for proximity-based services and location awareness.

## Features

- **iBeacon Protocol**: Implements the Apple iBeacon standard for maximum compatibility
- **Configurable Parameters**: Customizable UUID, Major/Minor values, and TX Power
- **Low Power**: Built on .NET nanoFramework for efficient resource usage
- **Simple API**: Easy-to-use Beacon class for beacon management

## Hardware Requirements

- A device with Bluetooth Low Energy (BLE) support
- Compatible with .NET nanoFramework
- Examples: ESP32, STM32 boards with BLE capability

## Software Requirements

- .NET nanoFramework v1.0
- Visual Studio with nanoFramework extension

## Dependencies

The project uses the following NuGet packages:

- `nanoFramework.CoreLibrary` (v1.17.11)
- `nanoFramework.Device.Bluetooth` (v1.1.115)
- `nanoFramework.Runtime.Events` (v1.11.32)
- `nanoFramework.Runtime.Native` (v1.7.11)
- `nanoFramework.System.Collections` (v1.5.67)
- `nanoFramework.System.Text` (v1.3.42)

## Getting Started

### Building the Project

1. Clone this repository
2. Open `ProximityBeaconSln.sln` in Visual Studio
3. Restore NuGet packages
4. Build the solution

### Deploying to Device

1. Connect your nanoFramework-compatible device
2. Set the deployment target in Visual Studio
3. Deploy the application to your device

### Usage

The application automatically starts broadcasting as a beacon when deployed. The default configuration uses:

- **UUID**: `E2C56DB5-DFFB-48D2-B060-D0F5A71096E0`
- **Major**: `1`
- **Minor**: `6`
- **TX Power**: `-59 dBm`

## Code Structure

### Program.cs

The main entry point that initializes and starts the beacon service. The application runs indefinitely, continuously broadcasting the beacon signal.

### Beacon.cs

The core beacon implementation that:
- Configures BLE advertisement parameters
- Sets up iBeacon manufacturer data format
- Manages the Bluetooth LE advertisement publisher
- Provides start/stop functionality

## Customization

To modify the beacon parameters, update the values in `Program.cs`:

```csharp
Guid proximityUUID = new Guid("E2C56DB5-DFFB-48D2-B060-D0F5A71096E0");
Beacon beacon = new Beacon(proximityUUID, major, minor, txPower);
```

### Parameters Explained

- **UUID**: Unique identifier for your beacon network (typically one per app/organization)
- **Major**: Primary identifier for grouping beacons (e.g., building or floor)
- **Minor**: Secondary identifier for individual beacons (e.g., specific room or location)
- **TX Power**: Calibrated signal strength for distance estimation

## Detection

The beacon can be detected by:
- iOS devices using Core Location framework
- Android devices using beacon scanning libraries
- Other BLE-enabled devices and applications

## Use Cases

- **Indoor Navigation**: Guide users through buildings or venues
- **Proximity Marketing**: Trigger content when users are nearby
- **Asset Tracking**: Monitor the location of equipment or items
- **Automated Check-ins**: Automatic presence detection
- **Context-Aware Apps**: Provide location-specific functionality

## License

This project is part of a training exercise for .NET nanoFramework development.

## Support

For issues related to .NET nanoFramework, visit the [official documentation](https://docs.nanoframework.net/).

## Contributing

This is a training project. For contributions to the .NET nanoFramework ecosystem, please visit the [nanoFramework GitHub organization](https://github.com/nanoframework).