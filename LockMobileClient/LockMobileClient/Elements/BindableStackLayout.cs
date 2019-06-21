using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace LockMobileClient.Elements
{
    public class BindableStackLayout : StackLayout
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(ObservableCollection<View>), typeof(BindableStackLayout), null,
                propertyChanged: (b, o, n) =>
                {
                    (n as ObservableCollection<View>).CollectionChanged += (coll, arg) =>
                    {
                        switch (arg.Action)
                        {
                            case NotifyCollectionChangedAction.Add:
                                foreach (var v in arg.NewItems)
                                    (b as BindableStackLayout).Children.Add((View)v);
                                break;
                            case NotifyCollectionChangedAction.Remove:
                                foreach (var v in arg.NewItems)
                                    (b as BindableStackLayout).Children.Remove((View)v);
                                break;
                        }
                    };
                });

        public ObservableCollection<View> Items
        {
            get { return (ObservableCollection<View>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
    }
}
