using Xamarin.Forms;

namespace LockMobileClient.Elements
{
    public class ChangeColorOnReleaseImageButton : TriggerAction<ImageButton>
    {
        protected override void Invoke(ImageButton sender)
        {
            sender.BackgroundColor = Color.Transparent;
        }
    }
}
