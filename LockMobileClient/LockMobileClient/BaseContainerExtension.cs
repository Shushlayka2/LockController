using LockMobileClient.Services;
using LockMobileClient.ViewModels;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Unity;
using Unity.Extension;
using Unity.Injection;
using Unity.Lifetime;

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
            Container.RegisterInstance<IBluetoothLE>(CrossBluetoothLE.Current, new ContainerControlledLifetimeManager());
            Container.RegisterInstance<IAdapter>(CrossBluetoothLE.Current.Adapter, new ContainerControlledLifetimeManager());
            Container.RegisterType<IBluetoothService, BluetoothService>(new InjectionConstructor(typeof(IBluetoothLE), typeof(IAdapter)));
            Container.RegisterType<RegistrationViewModel>();
            Container.RegisterType<InnerRegistrationViewModel>();
            Container.RegisterType<MainViewModel>(new InjectionConstructor(typeof(IIoTServiceProxy), typeof(INavigationService)));
            Container.RegisterType<IIoTServiceProxy, IoTServiceProxy>();
        }
    }
}
