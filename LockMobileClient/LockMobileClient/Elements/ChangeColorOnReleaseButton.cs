using Xamarin.Forms;

namespace LockMobileClient.Elements
{
    public class ChangeColorOnReleaseButton : TriggerAction<Button>
    {
        protected override void Invoke(Button sender)
        {
            sender.BackgroundColor = Color.Transparent;
        }
    }
}
