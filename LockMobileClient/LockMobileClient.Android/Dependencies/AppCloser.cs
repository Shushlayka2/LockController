using LockMobileClient.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(LockMobileClient.Droid.Dependencies.AppCloser))]
namespace LockMobileClient.Droid.Dependencies
{
    public class AppCloser : IAppCloser
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}