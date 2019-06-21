using LockMobileClient.Services;
using LockMobileClient.ViewModels;
using Unity;
using Unity.Extension;
using Unity.Injection;

namespace LockMobileClient
{
    public class BaseContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
#if DEBUG
            Container.AddExtension(new Diagnostic());
#endif
            Container.RegisterType<INavigationService, NavigationService>();
            Container.RegisterType<IRemoteServerSyncProxy, RemoteServerSyncProxy>();
            Container.RegisterType<RegistrationViewModel>();
            Container.RegisterType<InnerRegistrationViewModel>();
            Container.RegisterType<LoginViewModel>();
            Container.RegisterType<MainViewModel>(new InjectionConstructor(typeof(IIoTServiceProxy), typeof(INavigationService)));
            Container.RegisterType<IIoTServiceProxy, IoTServiceProxy>();
        }
    }
}
