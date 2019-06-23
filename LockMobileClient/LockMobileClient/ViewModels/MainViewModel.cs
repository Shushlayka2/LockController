using LockMobileClient.Models;
using LockMobileClient.Services;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Threading.Tasks;

namespace LockMobileClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string ImageSource { get; set; }
        public string CommandText { get; set; }
        public bool IsLoaded { get; set; }

        private LockState lockState;
        public LockState LockState
        {
            get { return lockState; }
            set
            {
                lockState = value;
                if (lockState == LockState.Opened)
                {
                    CommandText = "Opened";
                    ImageSource = "lock_opened.png";
                }
                else
                {
                    CommandText = "Closed";
                    ImageSource = "lock_closed.png";
                }
            }
        }

        protected INavigationService NavigationService { get; }
        protected IIoTServiceProxy IoTServiceProxy { get; }

        public MainViewModel(IIoTServiceProxy _IoTServiceProxy, INavigationService navigationService)
        {
            IsBusy = true;
            IsLoaded = false;
            NavigationService = navigationService;
            IoTServiceProxy = _IoTServiceProxy;
            ImageSource = "";
            CheckLockStateAsync();
        }

        protected async Task ManageFingerPrintAsync()
        {
            while (true)
            {
                AuthenticationRequestConfiguration config = new AuthenticationRequestConfiguration("");
                config.UseDialog = false;
                var result = await CrossFingerprint.Current.AuthenticateAsync(config);
                if (!IsBusy && result.Authenticated)
                {
                    IsBusy = true;
                    LockState = await IoTServiceProxy.ChangeLockStateAsync();
                    IsBusy = false;
                }
            }
        }

        protected async void CheckLockStateAsync()
        {
            try
            {
                LockState = await IoTServiceProxy.GetLockStatusAsync();
                IsBusy = false;
                IsLoaded = true;
                await ManageFingerPrintAsync();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await NavigationService.GetCurrentPage().DisplayAlert("IoT controller exception", "Connection invalid", "OK");
                await NavigationService.PopAsync();
            }
        }
    }
}
