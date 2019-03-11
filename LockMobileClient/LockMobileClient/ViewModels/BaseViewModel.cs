using System.ComponentModel;

namespace LockMobileClient.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public bool IsBusy { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
