using LockMobileClient.Models;
using LockMobileClient.Services;
using LockMobileClient.Validations;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LockMobileClient.ViewModels
{
    public class InnerRegistrationViewModel : BaseViewModel
    {
        public ICommand ConfirmCmd { get; }
        public ICommand AddNumButtonCmd { get; }
        public ICommand DeleteLastNumCmd { get; }
        public ValidatablePassword Password { get; }

        protected INavigationService NavigationService { get; }

        public InnerRegistrationViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            AddNumButtonCmd = new Command((num) => AddNum((string)num));
            DeleteLastNumCmd = new Command(() => DeleteLastNum());
            ConfirmCmd = new Command(() => ConfirmAsync(), () => Password.IsValid);
            Password = new ValidatablePassword(PropChangedCallBack, new PasswordValidator());
        }

        protected Action PropChangedCallBack => (ConfirmCmd as Command).ChangeCanExecute;

        protected void AddNum(string num)
        {
            Password.Value += num;
        }

        protected void DeleteLastNum()
        {
            if (!string.IsNullOrEmpty(Password.Value))
            {
                Password.Value = Password.Value.Remove(Password.Value.Length - 1);
            }
        }

        protected async void ConfirmAsync()
        {
        }
    }
}
