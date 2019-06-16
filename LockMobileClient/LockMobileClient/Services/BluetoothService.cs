using Plugin.BLE.Abstractions.Contracts;
using System.Collections.ObjectModel;

namespace LockMobileClient.Services
{
    public class BluetoothService : IBluetoothService
    {
        public IBluetoothLE BLE { get; }
        public IAdapter Adapter { get; }
        
        protected ObservableCollection<IDevice> DeviceList = new ObservableCollection<IDevice>();

        public BluetoothService(IBluetoothLE ble, IAdapter adapter)
        {
            BLE = ble;
            Adapter = adapter;
        }

        public bool CheckBluetoothState()
        {
            if (BLE.State == BluetoothState.Off)
            {
                return true;
            }
            else
            {
                DevicesTestAsync();
                return false;
            }
        }

        protected async void DevicesTestAsync()
        {
            Adapter.DeviceDiscovered += (s, a) => DeviceList.Add(a.Device);
            await Adapter.StartScanningForDevicesAsync();
        }
    }
}
