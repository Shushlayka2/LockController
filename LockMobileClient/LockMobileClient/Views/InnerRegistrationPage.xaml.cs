﻿using LockMobileClient.ViewModels;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LockMobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InnerRegistrationPage : ContentPage
    {
        public InnerRegistrationPage()
        {
            InitializeComponent();
            BindingContext = (Application.Current as App).Container.Resolve<InnerRegistrationViewModel>();
        }
    }
}