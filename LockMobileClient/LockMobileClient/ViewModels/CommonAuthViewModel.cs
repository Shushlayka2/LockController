using LockMobileClient.Models;
using LockMobileClient.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace LockMobileClient.ViewModels
{
    public abstract class CommonAuthViewModel : BaseViewModel
    {
        public ICommand CloseAppCmd { get; }
        public ICommand AddNumButtonCmd { get; }
        public ICommand DeleteLastNumCmd { get; }
        public abstract ValidatablePassword Password { get; protected set; }

        protected INavigationService NavigationService { get; }

        public CommonAuthViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            AddNumButtonCmd = new Command((num) => AddNum((string)num));
            DeleteLastNumCmd = new Command(() => DeleteLastNum());
            CloseAppCmd = new Command(() => CloseApp());
        }

        protected abstract void AddNum(string num);

        protected abstract void DeleteLastNum();
        

        protected void CloseApp()
        {
            DependencyService.Get<IAppCloser>().CloseApp();
        }
    }
}
