using LockMobileClient.Models;
using LockMobileClient.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LockMobileClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string ImageSource { get; set; }
        public string CommandText { get; set; }
        public ICommand LockCmd { get; }

        private LockState lockState;
        public LockState LockState
        {
            get { return lockState; }
            set
            {
                lockState = value;
                if (lockState == LockState.Opened)
                {
                    CommandText = "Close";
                    ImageSource = "close_lock.png";
                }
                else
                {
                    CommandText = "Open";
                    ImageSource = "open_lock.png";
                }
            }
        }

        protected INavigationService NavigationService { get; }
        protected IIoTServiceProxy IoTServiceProxy { get; }

        public MainViewModel(IIoTServiceProxy _IoTServiceProxy, INavigationService navigationService)
        {
            IsBusy = true;
            NavigationService = navigationService;
            IoTServiceProxy = _IoTServiceProxy;
            LockCmd = new Command(() => LockAsync());
            ImageSource = "open_lock.png";
            CheckLockStateAsync();
        }

        protected async void LockAsync()
        {
            LockState = await IoTServiceProxy.ChangeLockStateAsync();
        }

        protected async void CheckLockStateAsync()
        {
            try
            {
                LockState = await IoTServiceProxy.GetLockStatusAsync();
            }
            catch (Exception ex)
            {
                await NavigationService.GetCurrentPage().DisplayAlert("IoT controller exception", "Connection invalid", "OK");
                await NavigationService.PopAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
