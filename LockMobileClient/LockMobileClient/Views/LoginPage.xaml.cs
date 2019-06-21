using LockMobileClient.ViewModels;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LockMobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            var vm = (Application.Current as App).Container.Resolve<LoginViewModel>();
            BindingContext = vm;
            vm.GeneratePoints();
        }
    }
}