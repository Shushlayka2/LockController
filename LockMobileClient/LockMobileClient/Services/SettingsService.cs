using PCLAppConfig;
using Xamarin.Essentials;

namespace LockMobileClient.Services
{
    public static class SettingsService
    {
        internal static string DeviceId
        {
            get
            {
                return SecureStorage.GetAsync("DeviceId").Result;
            }
            set
            {
                SecureStorage.SetAsync("DeviceId", value);
            }
        }

        internal static string Password
        {
            get
            {
                return SecureStorage.GetAsync("Password").Result;
            }
            set
            {
                SecureStorage.SetAsync("Password", value);
            }
        }

        internal static string LockId
        {
            get
            {
                return SecureStorage.GetAsync("LockId").Result;
            }
            set
            {
                SecureStorage.SetAsync("LockId", value);
            }
        }

        internal static string ServiceConnectionString
        {
            get
            {
                return SecureStorage.GetAsync("ServiceConnectionString").Result;
            }
            set
            {
                SecureStorage.SetAsync("ServiceConnectionString", value);
            }
        }

        internal static string BaseAddress { get; } = ConfigurationManager.AppSettings["BaseAddress"];
    }
}
