using LockMobileClient.Models;
using LockMobileClient.Services;
using LockMobileClient.Validations;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LockMobileClient.ViewModels
{
    public class LoginViewModel : CommonAuthViewModel
    {
        public ObservableCollection<View> Points { get; set; }
        public override ValidatablePassword Password { get; protected set; }

        public LoginViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Password = new ValidatablePassword(null, new PasswordValidator());
            Points = new ObservableCollection<View>();
        }

        protected override async void AddNum(string num)
        {
            Password.Value += num;
            Points[Password.Value.Length - 1].BackgroundColor = Color.White;
            if (Password.Value.Length == 5)
            {
                if (Password.Value == SettingsService.Password)
                {
                    await NavigationService.PushAsync(new MainPage());
                    Points.Select(p => p.BackgroundColor = Color.Gray);
                    foreach (var p in Points)
                    {
                        p.BackgroundColor = Color.Gray;
                    }
                }
                else
                {
                    Vibration.Vibrate();
                    Password.Value = "";
                    Points.Select(p => p.BackgroundColor = Color.Gray);
                    foreach (var p in Points)
                    {
                        p.BackgroundColor = Color.Gray;
                    }
                }
            }
        }

        protected override void DeleteLastNum()
        {
            if (!string.IsNullOrEmpty(Password.Value))
            {
                Points[Password.Value.Length - 1].BackgroundColor = Color.Gray;
                Password.Value = Password.Value.Remove(Password.Value.Length - 1);
            }
        }

        public void GeneratePoints()
        {
            for (int i = 0; i < 5; i++)
            {
                var frame = new Frame()
                {
                    HeightRequest = 1,
                    WidthRequest = 1,
                    CornerRadius = 20,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    BackgroundColor = Color.Gray
                };
                if (i == 0)
                {
                    frame.Margin = new Thickness(8, 0, 0, 0);
                }
                Points.Add(frame);
            }
        }
    }
}
