using LockMobileClient.Models;
using LockMobileClient.Services;
using LockMobileClient.Validations;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LockMobileClient.ViewModels
{
    public class InnerRegistrationViewModel : CommonAuthViewModel
    {
        public ICommand ConfirmCmd { get; }
        public override ValidatablePassword Password { get; protected set; }
        public InnerRegistrationViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ConfirmCmd = new Command(() => ConfirmAsync(), () => Password.IsValid);
            Password = new ValidatablePassword(PropChangedCallBack, new PasswordValidator());
        }

        protected Action PropChangedCallBack => (ConfirmCmd as Command).ChangeCanExecute;

        protected override void AddNum(string num)
        {
            Password.Value += num;
        }

        protected override void DeleteLastNum()
        {
            if (!string.IsNullOrEmpty(Password.Value))
            {
                Password.Value = Password.Value.Remove(Password.Value.Length - 1);
            }
        }

        protected async void ConfirmAsync()
        {
            SettingsService.Password = Password.Value;
            await NavigationService.PushAsync(new MainPage());
        }
    }
}
