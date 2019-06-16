using LockMobileClient.Models;
using System.Threading.Tasks;

namespace LockMobileClient.Services
{
    public interface IIoTServiceProxy
    {
        Task<LockState> GetLockStatusAsync();
        Task<LockState> ChangeLockStateAsync();
    }
}
