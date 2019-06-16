using LockMobileClient.ViewModels;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LockMobileClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = (Application.Current as App).Container.Resolve<MainViewModel>();
        }
    }
}
