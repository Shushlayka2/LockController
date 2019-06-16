using LockMobileClient.Models;
using LockMobileClient.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace LockMobileClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public string ImageSource { get; set; }
        //public bool IsAlertShown { get; set; }
        public string CommandText { get; set; }
        public ICommand LockCmd { get; }

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

        //protected IBluetoothService BluetoothService { get; }
        protected INavigationService NavigationService { get; }
        protected IIoTServiceProxy IoTServiceProxy { get; }

        public MainViewModel(IIoTServiceProxy _IoTServiceProxy, INavigationService navigationService)
        {
            NavigationService = navigationService;
            IoTServiceProxy = _IoTServiceProxy;
            LockCmd = new Command(() => LockAsync());
            ImageSource = "open_lock.png";
            CheckLockStateAsync();
        }

        protected async void LockAsync()
        {
            LockState = await IoTServiceProxy.ChangeLockStateAsync();
        }

        protected async void CheckLockStateAsync()
        {
            LockState = await IoTServiceProxy.GetLockStatusAsync();
        }
    }
}
