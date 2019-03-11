using System.Threading.Tasks;
using Xamarin.Forms;

namespace LockMobileClient.Services
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task PopAsync();
        Page GetCurrentPage();
        Page GetPreviousPage();
        void RemovePreviousPage();
    }
}
