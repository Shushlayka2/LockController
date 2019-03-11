using LockMobileClient.Services;
using LockMobileClient.ViewModels;
using Unity;
using Unity.Extension;

namespace LockMobileClient
{
    public class BaseContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<INavigationService, NavigationService>();
            Container.RegisterType<IRemoteServerSyncProxy, RemoteServerSyncProxy>();
            Container.RegisterType<RegistrationViewModel>();
            Container.RegisterType<InnerRegistrationViewModel>();
        }
    }
}
