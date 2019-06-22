using LockMobileClient.Models;
using LockMobileClient.Services;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;

namespace LockMobileClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string ImageSource { get; set; }
        public string CommandText { get; set; }

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
            CommandText = "Open";
            ImageSource = "open_lock.png";
            CheckLockStateAsync();
            ManageFingerPrint();
        }

        protected async void ManageFingerPrint()
        {
            AuthenticationRequestConfiguration config = new AuthenticationRequestConfiguration("");
            config.UseDialog = false;
            var result = await CrossFingerprint.Current.AuthenticateAsync(config);
            if (!IsBusy && result.Authenticated)
            {
                LockState = await IoTServiceProxy.ChangeLockStateAsync();
            }
            ManageFingerPrint();
        }

        protected async void CheckLockStateAsync()
        {
            try
            {
                LockState = await IoTServiceProxy.GetLockStatusAsync();
            }
            catch (Exception ex)
            {
                IsBusy = false;
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
