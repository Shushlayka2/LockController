using LockMobileClient.Models;
using Microsoft.Azure.Devices;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace LockMobileClient.Services
{
    public class IoTServiceProxy : IIoTServiceProxy
    {
        private ServiceClient serviceClient;

        public IoTServiceProxy()
        {
            serviceClient = ServiceClient.CreateFromConnectionString(SettingsService.ServiceConnectionString);
        }

        public async Task<LockState> ChangeLockStateAsync()
        {
            var methodInvocation = new CloudToDeviceMethod("ChangeLockState") { ResponseTimeout = TimeSpan.FromSeconds(30) };
            var msg = "{\"deviceId\": \"" + SettingsService.DeviceId + "\"}";
            methodInvocation.SetPayloadJson(msg);
            var response = await serviceClient.InvokeDeviceMethodAsync(SettingsService.LockId, methodInvocation);
            var status = JObject.Parse(response.GetPayloadAsJson())["result"].ToString();
            return (LockState)Enum.Parse(typeof(LockState), status);
        }

        public async Task<LockState> GetLockStatusAsync()
        {
            var methodInvocation = new CloudToDeviceMethod("SendLockState") { ResponseTimeout = TimeSpan.FromSeconds(30) };
            var msg = "{\"deviceId\": \"" + SettingsService.DeviceId + "\"}";
            methodInvocation.SetPayloadJson(msg);
            var response = await serviceClient.InvokeDeviceMethodAsync(SettingsService.LockId, methodInvocation);
            var status = JObject.Parse(response.GetPayloadAsJson())["result"].ToString();
            return (LockState)Enum.Parse(typeof(LockState), status);
        }
    }
}
