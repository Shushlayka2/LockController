namespace LockMobileClient.Services
{
    public interface IRemoteServerSyncProxy
    {
        (string deviceId, string config) Register(string code);
    }
}
