using Plugin.BLE.Abstractions.Contracts;

namespace LockMobileClient.Services
{
    public interface IBluetoothService
    {
        IBluetoothLE BLE { get; }
        IAdapter Adapter { get; }

        bool CheckBluetoothState();
    }
}
