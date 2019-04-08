using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using LockMobileClient.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomPasswordEntryRenderer))]
namespace LockMobileClient.Droid.Renderers
{
    public class CustomPasswordEntryRenderer : EntryRenderer
    {
        public CustomPasswordEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#C8CED4"));
            else
                Control.Background.SetColorFilter(Android.Graphics.Color.White, PorterDuff.Mode.SrcAtop);
        }
    }
}