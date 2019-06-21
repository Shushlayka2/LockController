using Xamarin.Forms;

namespace LockMobileClient.Elements
{
    public class ChangeColorOnPressButton : TriggerAction<Button>
    {
        protected override void Invoke(Button sender)
        {
            sender.BackgroundColor = Color.Gray;
        }
    }
}
