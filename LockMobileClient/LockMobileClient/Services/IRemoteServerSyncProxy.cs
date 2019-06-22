using System.Threading.Tasks;

namespace LockMobileClient.Services
{
    public interface IRemoteServerSyncProxy
    {
        Task<(string deviceId, string lockId, string config)> RegisterAsync(string code);
    }
}
