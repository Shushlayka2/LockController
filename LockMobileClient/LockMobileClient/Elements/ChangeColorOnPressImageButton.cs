using Xamarin.Forms;

namespace LockMobileClient.Elements
{
    public class ChangeColorOnPressImageButton : TriggerAction<ImageButton>
    {
        protected override void Invoke(ImageButton sender)
        {
            sender.BackgroundColor = Color.Gray;
        }
    }
}
