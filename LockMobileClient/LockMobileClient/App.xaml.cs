﻿using LockMobileClient.Services;
using LockMobileClient.Views;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LockMobileClient
{
    public partial class App : Application
    {
        public IUnityContainer Container { get; } = new UnityContainer();

        public App()
        {
            InitializeComponent();
            Container.AddExtension(new BaseContainerExtension());
            if ((SettingsService.DeviceId == null) || (SettingsService.DeviceId == ""))
            {
                MainPage = new NavigationPage(new RegistrationPage());
            }
            else
            {
                if ((SettingsService.Password == null) || (SettingsService.Password == ""))
                {
                    MainPage = new NavigationPage(new InnerRegistrationPage());
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
