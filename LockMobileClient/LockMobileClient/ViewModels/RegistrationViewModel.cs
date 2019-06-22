using LockMobileClient.Models;
using LockMobileClient.Services;
using LockMobileClient.Validations;
using LockMobileClient.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LockMobileClient.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public ICommand RegisterCmd { get; }
        public ValidatableCode SecretCode { get; }

        protected IRemoteServerSyncProxy RemoteServerSyncProxy { get; }
        protected INavigationService NavigationService { get; }

        public RegistrationViewModel(IRemoteServerSyncProxy proxy, INavigationService navigationService)
        {
            RemoteServerSyncProxy = proxy;
            NavigationService = navigationService;
            RegisterCmd = new Command(() => RegisterAsync(), () => SecretCode.IsValid);
            SecretCode = new ValidatableCode(PropChangedCallBack, new CodeValidator());
        }

        protected Action PropChangedCallBack => (RegisterCmd as Command).ChangeCanExecute;

        protected async void RegisterAsync()
        {
            IsBusy = true;
            try
            {
                (string deviceId, string lockId, string config) tuple = await RemoteServerSyncProxy.RegisterAsync(SecretCode.Value);
                if (tuple.deviceId != null)
                {
                    SettingsService.DeviceId = tuple.deviceId;
                    SettingsService.LockId = tuple.lockId;
                    SettingsService.ServiceConnectionString = tuple.config;
                    await NavigationService.PushAsync(new InnerRegistrationPage());
                    NavigationService.RemovePreviousPage();
                }
                else
                {
                    await NavigationService.GetCurrentPage().DisplayAlert("Authentication failed", "The typed code is not valid", "OK");
                }
            }
            catch (Exception ex)
            {
                //TODO: Prepare exception handling
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
