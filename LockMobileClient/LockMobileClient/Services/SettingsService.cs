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

        internal static string BaseAddress { get; } = ConfigurationManager.AppSettings["BaseAddress"];
    }
}
