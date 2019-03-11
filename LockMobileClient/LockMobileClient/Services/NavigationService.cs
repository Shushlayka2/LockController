using System.Threading.Tasks;
using Xamarin.Forms;

namespace LockMobileClient.Services
{
    public class NavigationService : INavigationService
    {
        public Task PushAsync(Page page) => GetCurrentNavigation().PushAsync(page);
        public Task PopAsync() => GetCurrentNavigation().PopAsync();
        public Page GetCurrentPage() => ((NavigationPage)(Application.Current as App).MainPage).CurrentPage;
        public Page GetPreviousPage() => GetCurrentNavigation().NavigationStack[GetCurrentNavigation().NavigationStack.Count - 2];
        public void RemovePreviousPage() => GetCurrentNavigation().RemovePage(GetPreviousPage());

        protected INavigation GetCurrentNavigation() => (Application.Current as App).MainPage.Navigation;
    }
}
